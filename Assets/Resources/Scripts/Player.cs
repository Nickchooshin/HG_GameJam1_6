using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool m_bMove;
	private int m_nCount;
	private float timer;
	private float m_fMoveSpeed;
	private Vector3[] m_vecTargetPos;
	private Vector3 m_vecStartPos;
	private Transform m_ThisTransform;

	// Use this for initialization
	void Start () {
		m_ThisTransform = this.transform;
		m_fMoveSpeed = 0.75f;
		m_vecStartPos = m_ThisTransform.position;

		m_vecTargetPos = new Vector3[3];
		m_vecTargetPos[0] = GameObject.Find ("Target1").transform.position - m_ThisTransform.parent.position;
		m_vecTargetPos[1] = GameObject.Find ("Target2").transform.position - m_ThisTransform.parent.position;
		m_vecTargetPos[2] = GameObject.Find ("Target3").transform.position - m_ThisTransform.parent.position;

		m_bMove = false;
		m_nCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_bMove)
		{
			timer += m_fMoveSpeed * Time.deltaTime;
			m_ThisTransform.position = Vector3.Lerp(m_vecStartPos,m_vecTargetPos[m_nCount],timer);

			if (m_ThisTransform.position == m_vecTargetPos[m_nCount])
			{
				m_bMove = false;
				m_ThisTransform.rotation *= Quaternion.Euler(0.0f, 180.0f, 0.0f);
				timer = 0;
				m_nCount ++;
			}
		}
	}
	public void SetStartPos ()
	{
		m_vecStartPos = m_ThisTransform.position;
	}

	public void SetMove (bool _value)
	{
		m_bMove = _value;
	}

	public int GetCount ()
	{
		return m_nCount;
	}
}
