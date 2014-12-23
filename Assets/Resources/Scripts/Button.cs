using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    public Sprite normalImage;
    public Sprite clickImage;

    public delegate void ButtonClick();
    public event ButtonClick eventClick = null;

    void Awake()
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

    public void SetAlpha(float fAlpha)
    {
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, fAlpha);
    }
}
