using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatInputManager : MonoBehaviour, Inputs.IBoatMapActions
{
    private Inputs _playerInputs;
    private Vector2 _rawMovementInput;
    private Vector2 _rawTurnInput;
    
    public int NormInputMove { get; private set; }
    public int NormInputTurn { get; private set; }
    public Vector3 MovementInput { get; private set; }
    public Vector3 TurnInput { get; private set; }

    private void Awake()
    {
        _playerInputs = new Inputs();
    }

    private void OnEnable()
    {
        _playerInputs.BoatMap.Enable();
        _playerInputs.BoatMap.SetCallbacks(this);
    }

    private void OnDisable()
    {
        _playerInputs.BoatMap.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _rawMovementInput = context.ReadValue<Vector2>();
        MovementInput = new Vector3(0,0,_rawMovementInput.y);
        // if (Mathf.Abs(_rawMovementInput.x) > 0.5f)
        // {
        //     NormInputMove = (int)(_rawMovementInput * Vector3.forward).normalized.x;
        // }
        // else
        // {
        //     NormInputMove = 0;
        // }
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        _rawTurnInput = context.ReadValue<Vector2>();
    }
}
