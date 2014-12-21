using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	
	private int Count;

	private LineRenderer _LineRenderer;
	private Vector3 currentPos;
	private Vector3 prevPos;

	// Use this for initialization
	void Start () {
		Count = 0;
		_LineRenderer = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			_LineRenderer.SetVertexCount(Count+1);
			currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.0f,0.0f,10.0f);
			_LineRenderer.SetPosition(Count,currentPos);
		}
		else if (Input.GetMouseButton(0))
		{
			currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.0f,0.0f,10.0f);

			if (currentPos != prevPos)
			{
				Count++;
				prevPos = currentPos;
				_LineRenderer.SetVertexCount(Count+1);
				_LineRenderer.SetPosition(Count,currentPos);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Count = 0;
			GameObject testObj = new GameObject();
			testObj.AddComponent<LineRenderer>();
			_LineRenderer = testObj.GetComponent<LineRenderer>();
			_LineRenderer.SetWidth(0.05f,0.05f);
			_LineRenderer.material = Resources.Load ("Materials/Red")as Material;
		}
	}
}
