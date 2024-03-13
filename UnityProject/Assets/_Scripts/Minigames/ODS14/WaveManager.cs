using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    
    [SerializeField] private float waveIntensity = 0f;
    [SerializeField] private float waveSpeed = 0f;

    private Material mat;
    private float _offset = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogError("WaterManager instance already exists, destroying instance");
            Destroy(this);
        }
        //mat = GetComponent<MeshRenderer>().material;
        //SetWaveValues();
    }

    private void Start()
    {
        //SetWaveValues();
    }

    private void Update()
    {
        //SetWaveValues();
        _offset += waveSpeed * Time.deltaTime;
    }

    public float GetWaveHeight(float x, float z)
    {
        return waveIntensity * Mathf.Sin((x + z) + _offset);
    }

    private void SetWaveValues()
    {
        waveIntensity = mat.GetFloat("_WaveIntensity");
        waveSpeed = mat.GetFloat("_WaveSpeed");
    }
}
