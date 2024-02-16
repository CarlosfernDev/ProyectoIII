using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODS2Singleton : MinigameParent
{
    public static ODS2Singleton Instance;

    public TimerMinigame timer;

    [Header("Granjas Valor")]
    public float AddTime;
    public float SeedTimer;
    public float WaterTimer;

    protected override void personalStart()
    {
        base.personalStart();
    }

    protected override void personalAwake()
    {
        base.personalAwake();
        Instance = this;
    }

    protected override void OnGameStart()
    {
        base.OnGameStart();
    }

}
