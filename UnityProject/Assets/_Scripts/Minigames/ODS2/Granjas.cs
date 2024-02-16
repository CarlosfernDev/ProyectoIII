using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CloudSpawner;

public class Granjas : LInteractableParent
{
    public enum FarmState { Wait, WaitPlayerInteraction, LoadSeed, WaitingWater, Recolect }

    public GameObject VegetalPrefab;

    public FarmState _farmState = FarmState.Wait;

    [SerializeField] private Slider SliderReady;
    private float TimeReference;

    private void Start()
    {
        SliderReady.gameObject.SetActive(false);
        SliderReady.maxValue = ODS2Singleton.Instance.SeedTimer;
        SliderReady.value = 0;
        IsInteractable = false;

        ODS2Singleton.Instance.OnGameStartEvent += OnGameStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (_farmState != FarmState.LoadSeed)
            return;

        UpdateValue();
    }

    public override void Interact()
    {
        if (_farmState != FarmState.WaitPlayerInteraction && _farmState != FarmState.WaitingWater &&  _farmState != FarmState.Recolect)
            return;

        if(_farmState == FarmState.Recolect)
        {
            FarmComplete();
            return;
        }

        SetSeed();


        base.Interact();
    }

    void SetSeed()
    {
        if (_farmState == FarmState.WaitPlayerInteraction)
        {
            TimeReference = Time.time;
            SliderReady.gameObject.SetActive(true);
        }

        IsInteractable = false;
        _farmState = FarmState.LoadSeed;
    }

    void OnGameStart()
    {
        ResetFarm();
        SetSeed();
        ODS2Singleton.Instance.OnGameStartEvent -= OnGameStart;
    }

    void UpdateValue()
    {
        if (!SliderReady.gameObject.activeSelf)
        {
            SliderReady.gameObject.SetActive(true);
        }

        float TimeLoad = (Time.time - TimeReference);
        TimeLoad = Mathf.Clamp(TimeLoad, 0, ODS2Singleton.Instance.SeedTimer);

        SliderReady.value = TimeLoad;

        if (TimeLoad == ODS2Singleton.Instance.SeedTimer    )
        {
            IsInteractable = true;
            _farmState = FarmState.Recolect;
            return;
        }
    }

    void FarmComplete()
    {
        _farmState = FarmState.WaitPlayerInteraction;
        SetSeed();

        GameObject vegetal = Instantiate(VegetalPrefab);
        Vegetal script = vegetal.GetComponent<Vegetal>();
        script.SetEquipableToPlayer();
        script.myFarm = this;
    }

    void ResetFarm()
    {
        SliderReady.gameObject.SetActive(false);
        _farmState = FarmState.WaitPlayerInteraction;
        IsInteractable = true;
    }

}
