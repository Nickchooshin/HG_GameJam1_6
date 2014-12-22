using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private Transform m_ThisTransform;

	private AudioSource m_BackGroundSound; 
	private AudioSource m_QuestionSound; 
	private AudioSource m_EffectSound; 

	private AudioClip m_BackGroundClip;
	private AudioClip[] m_QuestionClip;
	private AudioClip[] m_EffectClip;

	// Use this for initialization
	void Awake () {
		m_ThisTransform = this.transform;

		m_BackGroundSound = m_ThisTransform.FindChild ("BackGroundSound").GetComponent<AudioSource>();
		m_QuestionSound = m_ThisTransform.FindChild ("QuestionSound").GetComponent<AudioSource>();
		m_EffectSound = m_ThisTransform.FindChild ("EffectSound").GetComponent<AudioSource>();

		//BackGround Sound
		m_BackGroundClip = Resources.Load ("Sounds/BackGround/BGM_1", typeof(AudioClip)) as AudioClip;

		//Question Sound
		m_QuestionClip = new AudioClip[8];
		for (int i = 0; i < m_QuestionClip.Length; i++)
		{
			string path = "Sounds/Question/QuestionType_" + i.ToString();
			m_QuestionClip[i] = Resources.Load (path, typeof(AudioClip)) as AudioClip;
		}

		//Effect Sound
		m_EffectClip = new AudioClip[6];
		m_EffectClip[0] = Resources.Load ("Sounds/Effect/SE_Butten", typeof(AudioClip)) as AudioClip;
		m_EffectClip[1] = Resources.Load ("Sounds/Effect/SE_Pencil", typeof(AudioClip)) as AudioClip;
		m_EffectClip[2] = Resources.Load ("Sounds/Effect/SE_Eraser", typeof(AudioClip)) as AudioClip;
		m_EffectClip[3] = Resources.Load ("Sounds/Effect/SE_Run", typeof(AudioClip)) as AudioClip;
		m_EffectClip[4] = Resources.Load ("Sounds/Effect/SE_Success", typeof(AudioClip)) as AudioClip;
		m_EffectClip[5] = Resources.Load ("Sounds/Effect/SE_Fail", typeof(AudioClip)) as AudioClip;

		SetVulume (1.0f);
	}

	public void SetBackGroundSound ()
	{
		m_BackGroundSound.clip = m_BackGroundClip;
		m_BackGroundSound.Play();
	}

	public void SetQuestionSound (int _ClipNumber)
	{
		if (0 <= _ClipNumber && _ClipNumber < m_QuestionClip.Length)
		{
			m_QuestionSound.clip = m_QuestionClip[_ClipNumber];
			m_QuestionSound.PlayOneShot(m_QuestionClip[_ClipNumber]);
		}
	}

	public void SetEffectSound (int _ClipNumber)
	{
		if (0 <= _ClipNumber && _ClipNumber < m_EffectClip.Length)
		{
			m_EffectSound.clip = m_EffectClip[_ClipNumber];
			m_EffectSound.PlayOneShot(m_EffectClip[_ClipNumber]);
		}
	}
	public AudioSource GetBackGroundSound ()
	{
		return	m_BackGroundSound;
	}

	public AudioSource GetQuestionSound ()
	{
		return m_QuestionSound;
	}

	public AudioSource GetEffectSound ()
	{
		return m_EffectSound;
	}

	public void SetVulume (float _Volume)
	{
		m_BackGroundSound.volume = _Volume;
		m_QuestionSound.volume = _Volume;
		m_EffectSound.volume = _Volume;
	}
}
