using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Granjas : MonoBehaviour
{
    public enum FarmState { Wait, WaitPlayerInteraction, LoadSeed, WaitingWater, Recolect }
    public FarmState _farmState = FarmState.Wait;
    [SerializeField] private Slider SpawnSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
