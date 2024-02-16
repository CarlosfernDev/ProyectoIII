using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODS2Singleton : MinigameParent
{
    public static ODS2Singleton Instance;

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
