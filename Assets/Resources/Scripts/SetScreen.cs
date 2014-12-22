using UnityEngine;
using System.Collections;

public class SetScreen : MonoBehaviour {

    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width/16*9, true);
    }
}
