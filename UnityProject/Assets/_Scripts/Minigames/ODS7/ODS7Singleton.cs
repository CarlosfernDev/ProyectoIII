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
    public List<CloudSpawner> spawnersDisablingList;

    public float timeFabricaDestroy;
    public float[] timeCloudRestoration;
    public float timeCloudSpawn;
    public int maxClouds;
    public List<IAnube> cloudList;
    public GameObject CloudPrefab;

    [Header("Ghost Try")]
    public float tryintervalFix;
    public int ChanceBase;
    private float TimeTryReference;

    [Header("Punto Ecologico")]
    public float AddTime;

    public Transform SpawnParent;

    protected override void personalAwake()
    {
        cloudList = new List<IAnube>();
        spawnersDisablingList = new List<CloudSpawner>();
        Instance = this;
        base.personalAwake();
    }

    protected override void personalStart()
    {
        base.personalStart();
        timer.PreSetTimmer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - TimeTryReference < tryintervalFix)
            return;

        Debug.Log("Intento ciclo");

        if (Random.Range(0, ChanceBase) != 1 || spawnersDisablingList.Count == 0 || cloudList.Count == 0)
        {
            TimeTryReference = Time.time;
            return;
        }

        Debug.Log("ChanceDada");

        CloudSpawner objectiveFabric = spawnersDisablingList[Random.Range(0, spawnersDisablingList.Count)];
        IAnube objectiveCloud = cloudList[Random.Range(0, cloudList.Count)];

        if (objectiveFabric.IAObjective != null || objectiveCloud.objectiveCloudSpawner != null)
            return;

        objectiveFabric.IAObjective = objectiveCloud;
        objectiveCloud.objectiveCloudSpawner = objectiveFabric;

        objectiveCloud.WEGOINGTOFACTORYYYYYYYYBOYSSS(objectiveFabric.transform);
    }

    protected override void OnGameStart()
    {
        base.OnGameStart();
        timer.SetTimer();
        TimeTryReference = Time.time;
    }

}
