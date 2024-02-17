using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODS2Singleton : MinigameParent
{
    public static ODS2Singleton Instance;

    public TimerMinigame timer;

    [Header("Granjas Valor")]
    public float AddTime;
    public float ReduceTime;
    public float[] WaterTime;

    public float SeedTimer;
    public float WaterMaxTimer;
    public float CollectingTimer;



    protected override void personalStart()
    {
        base.personalStart();
        timer.PreSetTimmer();
    }

    protected override void personalAwake()
    {
        base.personalAwake();
        Instance = this;
    }

    protected override void OnGameStart()
    {
        base.OnGameStart();
        timer.SetTimer();
    }

}
