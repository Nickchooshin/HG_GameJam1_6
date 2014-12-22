using UnityEngine;
using System.Collections;
using System.IO;

public class ShowStroy {
	
	private GameObject m_objScene; 
	private string m_strSpritePath;
	private string m_strNarrationPath;
	private float m_fTime;

	public ShowStroy (string strFilePath)
	{
		strFilePath = Application.dataPath + "/" + strFilePath;
		FileStream fs = new FileStream(strFilePath, FileMode.Open);
		StreamReader sr = new StreamReader(fs);

		m_strSpritePath = sr.ReadLine ();
		//m_strNarrationPath = sr.ReadLine ();		//나레이션 녹음하면 추가
		m_fTime = float.Parse(sr.ReadLine ());

		m_objScene = new GameObject ();

		m_objScene.AddComponent<SpriteRenderer> ();
		m_objScene.GetComponent<SpriteRenderer> ().sortingLayerID = 1;
		m_objScene.GetComponent<SpriteRenderer> ().sprite = Resources.Load (m_strSpritePath, typeof(Sprite)) as Sprite;

		//m_objScene.AddComponent<AudioSource> ();	//나레이션 녹음하면 추가
		//m_objScene.GetComponent<AudioSource> ().PlayOneShot (Resources.Load(m_strNarrationPath,typeof(AudioClip)) as AudioClip);	//나레이션 녹음하면 추가

		fs.Close ();
		sr.Close ();
	}

	public GameObject GetObjScene()
	{
		return m_objScene;
	}

	public float GetTime()
	{
		return m_fTime;
	}
}
