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
        TextAsset textAsset = Resources.Load("txt/" + strFilePath) as TextAsset;
        TextReader reader = new StringReader(textAsset.text);

        m_strSpritePath = reader.ReadLine();
        m_strNarrationPath = reader.ReadLine ();		//나레이션 녹음하면 추가
        m_fTime = float.Parse(reader.ReadLine());

		m_objScene = new GameObject ();

		m_objScene.AddComponent<SpriteRenderer> ();
		m_objScene.GetComponent<SpriteRenderer> ().sortingLayerID = 1;
		m_objScene.GetComponent<SpriteRenderer> ().sprite = Resources.Load (m_strSpritePath, typeof(Sprite)) as Sprite;

		m_objScene.AddComponent<AudioSource> ();	//나레이션 녹음하면 추가
		m_objScene.GetComponent<AudioSource> ().PlayOneShot (Resources.Load(m_strNarrationPath,typeof(AudioClip)) as AudioClip);	//나레이션 녹음하면 추가

        reader.Close();
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
