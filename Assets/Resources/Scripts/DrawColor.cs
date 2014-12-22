using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawColor : MonoSingleton<DrawColor> {

    public Material material;
    public Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
}
