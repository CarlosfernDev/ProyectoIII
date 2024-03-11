using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODS12Manager : MinigameParent
{
    public static ODS12Manager Instance;
    public TimerMinigame timer;
    protected override void personalAwake()
    {
        Instance = this;
        base.personalAwake();
    }

    protected override void personalStart()
    {
        base.personalStart();
        timer.PreSetTimmer();
    }
}
