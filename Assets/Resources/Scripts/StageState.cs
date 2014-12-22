using UnityEngine;
using System.Collections;

public class StageState : MonoSingleton<StageState> {

    private int Stage = 1;
	private int MinStage = 1;
	private int MaxStage = 4;

    public override void Init()
    {
        DontDestroyOnLoad(this);
    }

    public void InitStage()
    {
        Stage = 1;
    }

    public void NextStage()
    {
        ++Stage;
    }

    public void PrevStage()
    {
        --Stage;
    }

    public int NowStage()
    {
        return Stage;
    }

    public void DestroySingleton()
    {
        Destroy(this);
    }

	public bool MaxStageCheck ()
	{
		if (Stage == MaxStage)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool MinStageCheck ()
	{
		if (Stage == MinStage)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
