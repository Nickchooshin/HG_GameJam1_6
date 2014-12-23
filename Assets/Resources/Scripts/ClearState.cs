using UnityEngine;
using System.Collections;

public class ClearState : MonoSingleton<ClearState> {
	
	private int clearCount;
	private bool clear;
	private bool firstClear;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		clearCount = 0;
		clear = false;
		firstClear = false;
	}

	public bool ClearCheck ()
	{
		return clear;
	} 

	public bool FirstClearCheck ()
	{
		return firstClear;
	}
	
	public void AddClearCount ()
	{
		if (clearCount == 0)
		{
			firstClear = true;
		}
		clearCount ++;
	}

	public void SetClear (bool _value)
	{
		clear = _value;
	}
}
