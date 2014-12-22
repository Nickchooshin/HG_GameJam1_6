using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorPenManager : MonoBehaviour {

    public List<GameObject> PenList;
    private GameObject selectedPen;
    private Vector3 vecPenMove = new Vector3(0.0f, 0.2f, 0.0f);

    void Start()
    {
        selectedPen = PenList[0];
        selectedPen.transform.position += vecPenMove;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                foreach (GameObject Pen in PenList)
                {
                    if (hit.collider.gameObject == Pen)
                    {
                        selectedPen.transform.position -= vecPenMove;
                        selectedPen = Pen;
                        selectedPen.transform.position += vecPenMove;

                        PenColor penColor = Pen.GetComponent<PenColor>();
                        DrawColor.Instance.color = penColor.color;
                        break;
                    }
                }
            }
        }
    }
}
