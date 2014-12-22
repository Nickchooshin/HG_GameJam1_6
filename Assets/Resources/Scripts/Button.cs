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

        if (normalImage != null)
            spriteRenderer.sprite = normalImage;
    }

    void OnMouseUp()
    {
        if (normalImage != null)
            spriteRenderer.sprite = normalImage;
    }

    void OnMouseDown()
    {
        if (clickImage != null)
            spriteRenderer.sprite = clickImage;

        if (eventClick != null)
            eventClick();
    }
}
