using UnityEngine;
using System.Collections;
using System.IO;

public class DrawBackground : MonoBehaviour {

    public SpriteRenderer background;
    public SpriteRenderer background_text;

    private float m_fWaitTime ;

    void Start()
    {
        TextAsset textAsset = Resources.Load("txt/Draw/DrawBackground" + StageState.Instance.NowStage()) as TextAsset;
        TextReader reader = new StringReader(textAsset.text);

        string strBackground = reader.ReadLine();
        string strAudio = reader.ReadLine();
		string strBGM = reader.ReadLine ();
        m_fWaitTime = float.Parse(reader.ReadLine());

        reader.Close();

        background.sprite = Resources.Load(strBackground, typeof(Sprite)) as Sprite;
        background.material.renderQueue = 0;

        background_text.sprite = Resources.Load(strBackground + "_text", typeof(Sprite)) as Sprite;
        background_text.material.renderQueue = 0;

        AudioClip SE_Chapter = Resources.Load(strAudio, typeof(AudioClip)) as AudioClip;
        AudioManager.Instance.PlayVoice(SE_Chapter);

		AudioClip BGM_Chapter = Resources.Load(strBGM, typeof(AudioClip)) as AudioClip;
		AudioManager.Instance.StopBGM ();
		AudioManager.Instance.PlayBGM(BGM_Chapter);

        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        const float fFadeOutTime = 1.5f;
        float fTime = 0.0f;

        yield return new WaitForSeconds(m_fWaitTime);

        while (true)
        {
            background_text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - (fTime / fFadeOutTime));

            if (fTime >= fFadeOutTime)
            {
                Destroy(background_text);
                StopCoroutine("FadeOut");
            }

            yield return null;
            fTime += Time.deltaTime;
        }
    }
}
