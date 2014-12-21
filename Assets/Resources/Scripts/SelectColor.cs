using UnityEngine;
using System.Collections;

public class SelectColor : MonoBehaviour {

    public Material color;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider == gameObject)
                DrawColor.Instance.color = color;
        }
    }
}
