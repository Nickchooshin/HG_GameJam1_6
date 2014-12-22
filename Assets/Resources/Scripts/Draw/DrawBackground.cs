using UnityEngine;
using System.Collections;
using System.IO;

public class DrawBackground : MonoBehaviour {

    void Start()
    {
        TextAsset textAsset = Resources.Load("txt/DrawBackground" + StageState.Instance.NowStage()) as TextAsset;
        TextReader reader = new StringReader(textAsset.text);

        string strBackground = reader.ReadLine();

        reader.Close();

        SpriteRenderer spriteRender = gameObject.GetComponent<SpriteRenderer>();
        spriteRender.sprite = Resources.Load(strBackground, typeof(Sprite)) as Sprite;
        spriteRender.material.renderQueue = 0;
    }
}
