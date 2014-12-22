using UnityEngine;
using System.IO;
using System.Collections;

public class Test : MonoBehaviour {

	private int currentStage;
	private int maxStage;
	private GameObject m_objQuestion;
	private GameObject[] m_objAnswer;
	private int m_nAnswer;


	// Use this for initialization
	void Start () {
		m_objQuestion = GameObject.Find ("Q");

		//수정 할수도 
		m_objAnswer = new GameObject[3];
		m_objAnswer[0] = GameObject.Find ("A1");
		m_objAnswer[1] = GameObject.Find ("A2");
		m_objAnswer[2] = GameObject.Find ("A3");

		currentStage = 1;
		maxStage = 10;
		SetStage (currentStage);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

			if(hit.collider != null) //&& hit.collider.transform == thisTransform)
			{
				if (hit.collider.name == "A" + m_nAnswer.ToString())
				{
					if (currentStage != maxStage)
					{
						currentStage ++;
						SetStage (currentStage);
					}
					Debug.Log ("S");
				}
				else
				{
					Debug.Log ("F");
				}
			}
		}
	}

	void SetStage (int _stage)
	{
		QuizLoad quiz = new QuizLoad ("Stage" + _stage + ".txt");

		m_objQuestion.GetComponent<SpriteRenderer>().sprite = Resources.Load(quiz.GetQuestion (),typeof(Sprite)) as Sprite;

		for (int i = 0; i < 3; i++)
		{
			m_objAnswer[i].GetComponent<SpriteRenderer>().sprite = Resources.Load(quiz.GetAnswer(i),typeof(Sprite)) as Sprite;
		}

		m_nAnswer = quiz.GetAnswerNum ();
	}
}
