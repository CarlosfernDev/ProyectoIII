using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudSpawner : LInteractableParent
{
    public enum factoryState {Wait, Spawning, Loading, Disable}
    public factoryState myFactoryState = factoryState.Wait;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Slider SpawnSlider;

    private bool _IsRecalculateTime;

    private float _TimeReferenceDestroy;
    
    private float _TimeReferenceSpawn;
    private float _SpawnTimeOffset = 0;

    private void Start()
    {
        SpawnSlider.maxValue = ODS7Singleton.Instance.timeCloudSpawn;
        SpawnSlider.value = ODS7Singleton.Instance.timeCloudSpawn;
        ODS7Singleton.Instance.OnGameStartEvent += OnGameStart;
        _TimeReferenceSpawn = Time.time;
    }

    private void Update()
    {
        if (!ODS7Singleton.Instance.gameIsActive)
            return;

        // Chequear si puede spawnear
        if (IsCloudSpawneable())
        {
            SpawnCloud();
        }
        // Si puede spawnea

        if (myFactoryState != factoryState.Loading)
            return;

        UpdateValue();
    }

    void UpdateValue()
    {
       float TimeLoad = ODS7Singleton.Instance.timeFabricaDestroy - (Time.time - _TimeReferenceDestroy);
        TimeLoad = Mathf.Clamp(TimeLoad, 0, ODS7Singleton.Instance.timeFabricaDestroy);

        // Valorar suma de fantasmas

        /* if(TimeLoad == ODS7Singleton.Instance.timeFabricaDestroy)
        {
            RestoreFactory();
            return; 
        } */

        if(TimeLoad == 0)
        {
            DisableFactory();
            return;
        }
    }

    bool IsCloudSpawneable()
    {
        if (myFactoryState != factoryState.Spawning)
            return false;

        if(ODS7Singleton.Instance.maxClouds <= ODS7Singleton.Instance.cloudList.Count)
            return false;

        float TimeSpawn = ODS7Singleton.Instance.timeCloudSpawn - ((Time.time - _TimeReferenceSpawn));
        TimeSpawn = Mathf.Clamp(TimeSpawn, 0, ODS7Singleton.Instance.timeCloudSpawn);

        SpawnSlider.value = TimeSpawn;

        if (TimeSpawn == 0)
            return true;

        return false;
    }

    void SpawnCloud()
    {
        GameObject Cloud = Instantiate(ODS7Singleton.Instance.CloudPrefab, spawnTransform);

        Cloud.transform.parent = ODS7Singleton.Instance.SpawnParent;

        ODS7Singleton.Instance.cloudList.Add(Cloud);
        _TimeReferenceSpawn = Time.time;
        _SpawnTimeOffset = 0;
    }

    void OnGameStart()
    {
        _TimeReferenceSpawn = Time.time;
        myFactoryState = factoryState.Spawning;
        ODS7Singleton.Instance.OnGameStartEvent -= OnGameStart;
    }

    void DisableFactory()
    {
        _SpawnTimeOffset = Time.time - _TimeReferenceSpawn;
        myFactoryState = factoryState.Disable;
    }

    void RestoreFactory()
    {
        _TimeReferenceSpawn = Time.time - _SpawnTimeOffset;
        myFactoryState = factoryState.Spawning;
    }

    public override void Interact()
    {
        base.Interact();

        if (myFactoryState != factoryState.Spawning)
            return;

        myFactoryState = factoryState.Loading;
        _TimeReferenceDestroy = Time.time;
    }

}
