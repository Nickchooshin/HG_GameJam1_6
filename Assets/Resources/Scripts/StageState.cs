using UnityEngine;
using System.Collections;

public class StageState : MonoSingleton<StageState> {

    private int Stage = 1;

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
}
