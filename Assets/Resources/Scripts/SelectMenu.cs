using UnityEngine;
using System.Collections;

public class SelectMenu : MonoBehaviour {
	private Color m_SelectMenuColor;
	private GameObject m_objMainButton;
	private GameObject[] m_MainButton;
	private GameObject m_objSelect_Window;
	private GameObject[] m_SelectGameType;
	private GameObject m_prevButton;
	private AudioClip SE_Button;

    private GameUnlock gameUnlockState;

	// Use this for initialization
	void Start () {
		//ClearState.Instance
		m_MainButton = new GameObject[3];
		m_MainButton [0] = GameObject.Find ("main_but_1");
		m_MainButton [1] = GameObject.Find ("main_but_2");
		m_MainButton [2] = GameObject.Find ("main_but_3");

		m_SelectGameType = new GameObject[3];
		m_SelectGameType[0] = GameObject.Find ("Select_DrawGame");
		m_SelectGameType[1] = GameObject.Find ("Select_QuizGame");
		m_SelectGameType[2] = GameObject.Find ("Back_Button");

		m_objMainButton = GameObject.Find ("Main_Button");
		m_objSelect_Window = GameObject.Find ("Select_Window");
		m_objSelect_Window.SetActive (false);

		m_SelectMenuColor = new Color (171.0f, 171.0f, 171.0f,255.0f) / 255;	//버튼 클릭 되었을 때의 색

		AudioClip BGM = Resources.Load("Sounds/BackGround/BGM_3", typeof(AudioClip)) as AudioClip;
		AudioManager.Instance.PlayBGM(BGM);

		SE_Button = Resources.Load("Sounds/Effect/SE_Butten", typeof(AudioClip)) as AudioClip;

		if (ClearState.Instance.ClearCheck())
		{
			m_objMainButton.SetActive (false);
			m_objSelect_Window.SetActive (true);

			ClearState.Instance.SetClear(false);
		}

        gameUnlockState = new GameUnlock();
        m_SelectGameType[0].active = gameUnlockState.BeGameUnlock();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			
			if(hit.collider != null)
			{
				AudioManager.Instance.PlaySE(SE_Button);
			}
		}
		else if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			
			if(hit.collider != null)
			{
				for (int i = 0; i < m_MainButton.Length; i++)
				{
					if(hit.collider.name == m_MainButton[i].name)
					{
						m_prevButton = hit.collider.gameObject;
						m_MainButton[i].GetComponent<SpriteRenderer>().color = m_SelectMenuColor;
						break;
					}
				}

				for (int i = 0; i < m_SelectGameType.Length; i++)
				{
					if(hit.collider.name == m_SelectGameType[i].name)
					{
						m_prevButton = hit.collider.gameObject;
						m_SelectGameType[i].GetComponent<SpriteRenderer>().color = m_SelectMenuColor;
						break;
					}
				}
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			
			if(hit.collider != null)
			{
				if(m_prevButton == hit.collider.gameObject)
				{
					if (hit.collider.gameObject == m_MainButton[0])
					{
						//SelectWindow
						GameObject skip = Instantiate(Resources.Load ("Prefabs/SkipButton")) as GameObject;
						ShowStroy story = new ShowStroy("Opening");
						skip.transform.parent =  story.GetObjScene().transform; 
						Destroy(story.GetObjScene(),story.GetTime());
						StartCoroutine(ButtonActive(story.GetTime()));

						AudioClip BGM = Resources.Load("Sounds/BackGround/BGM_4", typeof(AudioClip)) as AudioClip;
						AudioManager.Instance.StopBGM ();
						AudioManager.Instance.PlayBGM(BGM);
					}
					else if (hit.collider.gameObject == m_MainButton[1])
					{
                        Application.LoadLevel("creditScene");
					}
					else if (hit.collider.gameObject == m_MainButton[2])
					{
						Application.Quit();
					}
					else if (hit.collider.gameObject == m_SelectGameType[0])
					{
						Application.LoadLevel("drawScene");
					}
					else if (hit.collider.gameObject == m_SelectGameType[1])
					{
						Application.LoadLevel("QuizGame");
					}
					else if (hit.collider.gameObject == m_SelectGameType[2])
					{
						m_objMainButton.SetActive (true);
						m_objSelect_Window.SetActive (false);
					}
				}
			}

			for (int i = 0; i < m_MainButton.Length; i++)
			{
				m_MainButton[i].GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f);
			}

			for (int i = 0; i < m_SelectGameType.Length; i++)
			{
				m_SelectGameType[i].GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f);
			}
		}
	}
			
	IEnumerator ButtonActive (float _time)
	{
		m_objMainButton.SetActive (false);
	
		yield return new WaitForSeconds(_time);

		AudioClip BGM = Resources.Load("Sounds/BackGround/BGM_3", typeof(AudioClip)) as AudioClip;
		AudioManager.Instance.PlayBGM(BGM);
		m_objSelect_Window.SetActive (true);
	}
}
