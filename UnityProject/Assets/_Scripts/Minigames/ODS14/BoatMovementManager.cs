using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BoatMovementManager : MonoBehaviour
{
    [SerializeField] private TMP_Text velocityDebug;
    
    [SerializeField] private float topSpeed;
    [SerializeField] private float forceMult;
    [SerializeField] private float accel;
    [SerializeField] private float turnSpd;
    
    private BoatInputManager _inputManager;
    private Rigidbody _rb;

    private void OnEnable()
    {
        _inputManager = GetComponent<BoatInputManager>();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocityDebug.text = _rb.velocity.magnitude.ToString();
    }

    private void FixedUpdate()
    {
        _rb.AddRelativeTorque(_inputManager.TurnInput * turnSpd, ForceMode.Force);
        SpeedUp();
        // _rb.AddRelativeForce(_inputManager.MovementInput * accel, ForceMode.Acceleration);
    }

    private void SpeedUp()
    {
        if (_inputManager.MovementInput == Vector3.zero) return;
        Vector3 targetVelocity = _inputManager.MovementInput * topSpeed;
        Vector3 force = (targetVelocity - _rb.velocity) * forceMult;

        if (force.magnitude > forceMult)
        {
            force = force.normalized * forceMult;
        }
        _rb.AddRelativeForce(force);
    }
}
