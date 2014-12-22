using UnityEngine;
using System.Collections;

public class EraseButton : MonoBehaviour {

    Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();

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
    }
}
