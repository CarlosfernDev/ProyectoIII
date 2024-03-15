using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovementManager : MonoBehaviour
{
    [SerializeField] private BoatInputManager _inputManager;

    private void OnEnable()
    {
        _inputManager = GetComponent<BoatInputManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(_inputManager.MovementInput);
    }
}
