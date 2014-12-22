using UnityEngine;
using System.Collections;

public class StageClearMenu : MonoBehaviour {

    public Button[] ButtonList;

    void Start()
    {
        foreach (Button button in ButtonList)
        {
            button.collider2D.enabled = false;
            button.SetAlpha(0.0f);
        }

        ButtonList[0].eventClick += Again;
        ButtonList[1].eventClick += Next;
        ButtonList[2].eventClick += Prev;

        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        while (true)
        {
            if (DrawState.Instance.NextStage)
            {
                StartCoroutine("FadeIn");
                StopCoroutine("Delay");
            }

            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        const float fFadeInTime = 1.0f;
        float fTime = 0.0f;

        while (true)
        {
            foreach (Button button in ButtonList)
                button.SetAlpha((fTime / fFadeInTime));

            if (fTime >= fFadeInTime)
            {
                foreach (Button button in ButtonList)
                {
                    button.collider2D.enabled = true;
                    button.SetAlpha(1.0f);
                }

                StopCoroutine("FadeIn");
            }

            yield return null;
            fTime += Time.deltaTime;
        }
    }

    void Again()
    {
        Application.LoadLevel("drawScene");
    }

    void Next()
    {
		if (StageState.Instance.MaxStageCheck())
		{
			StageState.Instance.DestroySingleton();

			GameObject skip = Instantiate(Resources.Load ("Prefabs/SkipButton")) as GameObject;
			ShowStroy story = new ShowStroy("Ending01");
			skip.transform.parent =  story.GetObjScene().transform; 
			StartCoroutine(NextScene("Main",story.GetTime()));
		}
		else 
		{
        	StageState.Instance.NextStage();
        	Application.LoadLevel("drawScene");
		}
    }

    void Prev()
    {
		if (StageState.Instance.MinStageCheck() == false)
		{
        	StageState.Instance.PrevStage();
        	Application.LoadLevel("drawScene");
		}

    }

	IEnumerator NextScene (string _name,float _time)
	{
		yield return new WaitForSeconds(_time);
		Application.LoadLevel(_name);
	}
}
