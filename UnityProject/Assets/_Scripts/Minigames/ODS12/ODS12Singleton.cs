using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ODS12Singleton : MinigameParent
{
    public static ODS12Singleton Instance;
    
    public enum gameStage { Stage1, Stage2, Stage3 }
    public gameStage currentStage = gameStage.Stage1;
    
    public TimerMinigame gameTimer;

    public UnityEvent OnGarbageDelivered;
    public UnityEvent OnGarbageCreated;

    public Transform playerPickupTransform;
    
    public float currentGarbSpawnTime;
    public int maxGarbage = 10;
    public int currentGarbage = 0;

    [SerializeField] private float stage1GarbSpawnTime;
    [SerializeField] private float stage2GarbSpawnTime;
    [SerializeField] private float stage3GarbSpawnTime;

    private float _gameTimeThird;
    
    protected override void personalAwake()
    {
        Instance = this;
        base.personalAwake();
        OnGarbageDelivered.AddListener(ReduceCurrentGarbageCount);
        OnGarbageCreated.AddListener(IncreaseGarbageCount);

        //currentGarbSpawnTime = stage1GarbSpawnTime;
    }

    private void Update()
    {
        
    }

    protected override void personalStart()
    {
        base.personalStart();
        gameTimer.PreSetTimmer();
    }

    protected override void OnGameStart()
    {
        base.OnGameStart();
        gameTimer.SetTimer();
    }

    private void ReduceCurrentGarbageCount()
    {
        currentGarbage--;
    }

    private void IncreaseGarbageCount()
    {
        currentGarbage++;
    }
}
