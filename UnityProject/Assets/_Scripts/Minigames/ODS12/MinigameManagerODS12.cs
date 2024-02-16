using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManagerODS12 : MinigameParent
{
    public static MinigameManagerODS12 Instance;
    public TimerMinigame gameTimer;



    protected override void personalAwake()
    {
        Instance = this;
        base.personalAwake();
    }

    protected override void personalStart()
    {
        base.personalStart();
        //gameTimer.PreSetTimmer;
    }

    protected override void OnGameStart()
    {
        base.OnGameStart();
        gameTimer.SetTimer();
    }
}
