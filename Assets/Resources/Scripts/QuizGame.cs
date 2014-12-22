using UnityEngine;
using System.IO;
using System.Collections;

public class QuizGame : MonoBehaviour {

	private enum EffectType {Success, Fail}
	private EffectType m_eEffectType;
	
	private int currentStage;
	private int maxStage;
	private int m_nAnswer;

	private GUIText m_GUIQuestion;
	private GameObject m_objEffect;
	private GameObject m_objQuestion;
	private GameObject[] m_objAnswer;

	private Player m_srtPlayer;
	private GameObject m_objPlayer;
	private Vector3 m_vecStoryPos;
	private bool m_bStoryState;

	private Sprite[] m_sprBackGround;

	private SoundManager m_srtSoundManager;

	private float m_fShowTime;
	
	// Use this for initialization
	void Start () {
		m_srtSoundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();

		m_objQuestion = GameObject.Find ("QuestionObj");

		m_objAnswer = new GameObject[3];
		m_objAnswer[0] = GameObject.Find ("AnswerObj_1");
		m_objAnswer[1] = GameObject.Find ("AnswerObj_2");
		m_objAnswer[2] = GameObject.Find ("AnswerObj_3");

		m_sprBackGround = new Sprite[3];
		m_sprBackGround[0] = Resources.Load("Textures/QuizBackGround/Back_1",typeof(Sprite)) as Sprite;
		m_sprBackGround[1] = Resources.Load("Textures/QuizBackGround/Back_2",typeof(Sprite)) as Sprite;
		m_sprBackGround[2] = Resources.Load("Textures/QuizBackGround/Back_3",typeof(Sprite)) as Sprite;

		m_GUIQuestion = GameObject.Find ("GUI_Question").guiText;
	
		m_objPlayer = GameObject.Find ("Player");
		m_srtPlayer = m_objPlayer.GetComponent<Player> ();

		m_vecStoryPos = GameObject.Find ("StoryEffect").transform.position;

		m_fShowTime = 1.0f;

		currentStage = 1;
		maxStage = 22;
		SetStage (currentStage);

		m_srtSoundManager.SetBackGroundSound ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

			if(hit.collider != null && m_objEffect == null)
			{
				string path = "Textures/Circle_";
				GameObject temp = new GameObject();
				temp.AddComponent <SpriteRenderer>();
				temp.GetComponent<SpriteRenderer>().sortingLayerID = 2;	//2 = UI
				temp.GetComponent<SpriteRenderer>().sortingOrder = 1;	//그리는 순서
				temp.transform.position = hit.collider.transform.position;

				if (hit.collider.name == "AnswerObj_" + m_nAnswer.ToString())
				{
					path += "Success";
			
					StartCoroutine(AnswerEffect(m_fShowTime,EffectType.Success));
				}
				else
				{
					path += "Fail";

					StartCoroutine(AnswerEffect(m_fShowTime,EffectType.Fail));
				}

				temp.GetComponent<SpriteRenderer>().sprite = Resources.Load(path,typeof(Sprite)) as Sprite;
				Destroy(temp,m_fShowTime);
			}
		}
	}

	void SetStage (int _stage)
	{
		QuizLoad quiz = new QuizLoad ("Stage" + _stage);

		m_GUIQuestion.text = quiz.GetTextQuestion ();

		m_objQuestion.GetComponent<SpriteRenderer>().sprite = Resources.Load(quiz.GetQuestion (),typeof(Sprite)) as Sprite;

		for (int i = 0; i < 3; i++)
		{
			m_objAnswer[i].GetComponent<SpriteRenderer>().sprite = Resources.Load(quiz.GetAnswer(i),typeof(Sprite)) as Sprite;
		}

		m_nAnswer = quiz.GetAnswerNum ();

		m_bStoryState = quiz.GetStoryState ();

		m_srtSoundManager.SetQuestionSound (quiz.GetSoundType());
	}

	IEnumerator AnswerEffect (float _time, EffectType _type)
	{
		m_objEffect = Instantiate (Resources.Load ("Prefabs/Effect"), Vector3.zero, Quaternion.identity) as GameObject;
		m_objEffect.GetComponent<Animator> ().SetTrigger(_type.ToString());

		Destroy (m_objEffect, _time);

		if (_type == EffectType.Success)
		{
			m_srtSoundManager.SetEffectSound(4);
			yield return new WaitForSeconds (_time);

			if (m_bStoryState)
			{
				m_srtSoundManager.GetQuestionSound().Stop();	// 질문 소리 정지 

				m_objEffect = new GameObject();				// 스토리 연출 동안 클릭 방지

				m_GUIQuestion.text = "";
				m_objPlayer.transform.parent.position -= m_vecStoryPos;
				m_srtPlayer.SetStartPos();
				m_srtPlayer.SetMove(true);
				m_srtSoundManager.SetEffectSound(3);		//Run Sound

				yield return new WaitForSeconds (1.5f);		//계단 오르는 시간
			
				m_srtSoundManager.GetEffectSound().Stop();	// 달리는 소리 정지

				if (currentStage == maxStage)
				{
					StartCoroutine(Clear());
					Debug.Log ("Clear");
				}
				else 
				{
					Destroy(m_objEffect);						// 스토리 종료 후 파괴 

					m_srtPlayer.SetMove(false);
					m_objPlayer.transform.parent.position += m_vecStoryPos;

					GameObject.Find("BackGround").GetComponent<SpriteRenderer>().sprite = m_sprBackGround[m_srtPlayer.GetCount()];
					currentStage ++;
					SetStage (currentStage);
				}
			}
			else
			{
				currentStage ++;
				SetStage (currentStage);
			}
		}
		else if (_type == EffectType.Fail)
		{
			m_srtSoundManager.SetEffectSound(5);	//Fail Sound
			yield return new WaitForSeconds (_time);
		}
	}

	IEnumerator Clear ()
	{
		ShowStroy story = new ShowStroy("Ending02");
		Destroy (story.GetObjScene(), story.GetTime ());
		yield return new WaitForSeconds(story.GetTime());

		story = new ShowStroy("Ending03");
		Destroy (story.GetObjScene(), story.GetTime ());
		yield return new WaitForSeconds(story.GetTime());

		Destroy(m_objEffect);					

		Application.LoadLevel ("Main");
	}
}
