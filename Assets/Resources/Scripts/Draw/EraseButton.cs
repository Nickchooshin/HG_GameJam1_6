using UnityEngine;
using System.Collections;

public class EraseButton : MonoBehaviour {

    private Button button;

    private AudioClip SE_Eraser;

    void Start()
    {
        button = gameObject.GetComponent<Button>();

        SE_Eraser = Resources.Load("Sounds/Effect/SE_Eraser", typeof(AudioClip)) as AudioClip;

        button.eventClick += Erase;
    }

    void Update()
    {
        button.collider2D.enabled = !DrawState.Instance.NextStage;
    }

    void Erase()
    {
        GameObject[] LineObjects = GameObject.FindGameObjectsWithTag("Draw");

        foreach (GameObject LineObject in LineObjects)
            Destroy(LineObject);

        AudioManager.Instance.PlaySE(SE_Eraser);
    }
}
