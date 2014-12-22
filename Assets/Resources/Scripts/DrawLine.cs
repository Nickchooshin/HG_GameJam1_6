using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

	private int m_nCount;

	private LineRenderer m_LineRenderer;
	private Vector3 m_vecCurrentPos;
	private Vector3 m_vecPrevPos;
    private Vector3 m_vecCameraPos;

    public float LineWidth = 0.05f;
    private int renderQueue = 0;

	// Use this for initialization
	void Start () {
        m_vecCameraPos = -Camera.main.transform.position;
	}

    IEnumerator Draw()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InitLineRenderer();

                m_vecCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + m_vecCameraPos;

                m_LineRenderer.SetVertexCount(++m_nCount);
                m_LineRenderer.SetPosition(m_nCount - 1, m_vecCurrentPos);
            }
            else if (Input.GetMouseButton(0))
            {
                m_vecCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + m_vecCameraPos;

                if (m_vecCurrentPos != m_vecPrevPos)
                {
                    m_LineRenderer.SetVertexCount(++m_nCount);
                    m_LineRenderer.SetPosition(m_nCount - 1, m_vecCurrentPos);

                    m_vecPrevPos = m_vecCurrentPos;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopCoroutine("Draw");
            }

            yield return null;
        }
    }

    private void InitLineRenderer()
    {
        GameObject temp = new GameObject();
        temp.name = "Line";
        temp.tag = "Draw";
        m_LineRenderer = temp.AddComponent<LineRenderer>();

        m_LineRenderer.SetWidth(LineWidth, LineWidth);
        m_LineRenderer.material = DrawColor.Instance.material;
        m_LineRenderer.material.renderQueue = renderQueue;
        m_LineRenderer.material.color = DrawColor.Instance.color;
      
		m_nCount = 0;
        ++renderQueue;
    }
}