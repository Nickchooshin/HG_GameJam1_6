using UnityEngine;
using System.Collections;
using System.IO;

public class DrawBackground : MonoBehaviour {

    void Start()
    {
        string strFilePath = Application.dataPath + "/" + "DrawBackground" + StageState.Instance.NowStage() + ".txt";

        FileStream fs = new FileStream(strFilePath, FileMode.Open);
        StreamReader sr = new StreamReader(fs);

        string strBackground = sr.ReadLine();

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load(strBackground, typeof(Sprite)) as Sprite;
        spriteRenderer.material.renderQueue = 0;

        sr.Close();
    }
}
