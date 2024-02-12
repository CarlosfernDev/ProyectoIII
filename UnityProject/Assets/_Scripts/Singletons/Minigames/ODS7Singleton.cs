using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ODS7Singleton : MinigameParent
{
    public static ODS7Singleton Instance;

    [Header("Fabricas Variables")]
    public float timeFabricaDestroy;
    public float[] timeCloudRestoration;
    public float timeCloudSpawn;
    public int maxClouds;
    public List<GameObject> cloudList;
    public GameObject CloudPrefab;

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


}
