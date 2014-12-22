using UnityEngine;
using System.Collections;

public class Skip : MonoBehaviour {

	private SoundManager m_srtSoundManager;
	private string m_parentName;

	void Start ()
	{
		m_parentName = this.transform.parent.GetComponent<SpriteRenderer>().sprite.name;
	}


	void OnMouseDown ()
	{
		SkipStory ();
		Destroy (this.transform.parent.gameObject);
	}

	public void SkipStory ()
	{
		if (m_parentName == "Opening")
		{
			GameObject.Find("main_Background").GetComponent<SelectMenu>().StartCoroutine("ButtonActive",0);
		}
		else if (m_parentName == "Ending_1")
		{
			Application.LoadLevel ("Main");
		}
		else if (m_parentName == "Ending_2" || m_parentName == "Ending_3")
		{
			Application.LoadLevel ("Main");
		}
	}
}
