using UnityEngine;
using System.Collections;

public class NextStageButton : MonoBehaviour {

    Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();

        button.eventClick += NextStage;
    }

    void NextStage()
    {
    }
}
