using UnityEngine;
using System.Collections;

public class EraseButton : MonoBehaviour {

    Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();

        button.eventClick += Erase;
    }

    void Erase()
    {
        GameObject[] LineObjects = GameObject.FindGameObjectsWithTag("Draw");

        foreach (GameObject LineObject in LineObjects)
            Destroy(LineObject);
    }
}
