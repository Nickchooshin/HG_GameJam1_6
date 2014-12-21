using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawColor : MonoSingleton<DrawColor> {

    //private Dictionary<string, Material> m_ColorMap;
    public Material color;

    /*public void SetColor(string strColor)
    {
        if (!m_ColorMap.ContainsKey(strColor))
            m_ColorMap[strColor] = Resources.Load(strColor) as Material;

        color = m_ColorMap[strColor];
    }*/
}
