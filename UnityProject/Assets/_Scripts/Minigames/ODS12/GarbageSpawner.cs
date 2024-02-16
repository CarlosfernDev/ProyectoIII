using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CloudSpawner;

public class GarbageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject glass;
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject plastic;

    [SerializeField] private Slider spawnTimerSlider;

    [SerializeField] private float timeBetweenSpawn;

    private bool _canSpawn;
    private TimerMinigame _spawnTimer;

    private void Awake()
    {
        
    }

    private bool SpawnTimer()
    {
        if (!_canSpawn)
            return false;

        if (ODS7Singleton.Instance.maxClouds <= ODS7Singleton.Instance.cloudList.Count)
        {
            _TimeReferenceSpawn = Time.time;
            return false;
        }

        float TimeSpawn = ODS7Singleton.Instance.timeCloudSpawn - ((Time.time - _TimeReferenceSpawn));
        TimeSpawn = Mathf.Clamp(TimeSpawn, 0, ODS7Singleton.Instance.timeCloudSpawn);

        SpawnSlider.value = TimeSpawn;

        if (TimeSpawn == 0)
            return true;

        return false;
    }
}
