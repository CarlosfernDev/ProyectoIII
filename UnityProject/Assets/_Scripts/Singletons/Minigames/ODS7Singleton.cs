using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(TimerMinigame))]
public class ODS7Singleton : MinigameParent
{
    public static ODS7Singleton Instance;

    public TimerMinigame timer;

    [Header("Fabricas Variables")]
    public float timeFabricaDestroy;
    public float[] timeCloudRestoration;
    public float timeCloudSpawn;
    public int maxClouds;
    public List<GameObject> cloudList;
    public GameObject CloudPrefab;

    [Header("Punto Ecologico")]
    public float AddTime;

    public Transform SpawnParent;

    protected override void personalAwake()
    {
        cloudList = new List<GameObject>();
        Instance = this;
        base.personalAwake();
    }

    protected override void personalStart()
    {
        base.personalStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnGameStart()
    {
        base.OnGameStart();
        timer.SetTimer();
    }

}
