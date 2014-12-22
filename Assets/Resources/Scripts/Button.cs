using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    public Sprite normalImage;
    public Sprite clickImage;

    public delegate void ButtonClick();
    public event ButtonClick eventClick = null;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = normalImage;
    }

    void OnMouseUp()
    {
        spriteRenderer.sprite = normalImage;
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = clickImage;

        if (eventClick != null)
            eventClick();
    }
}
