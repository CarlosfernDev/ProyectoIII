using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private List<GameObject> floatPoints = new List<GameObject>();
    [SerializeField] private float depthBeforeSubmerged = 1f;
    [SerializeField] private float displacementAmount = 3f;
    [SerializeField] private float waterDrag = 0.99f;
    [SerializeField] private float waterAngularDrag = 0.5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        foreach (var point in floatPoints)
        {
            var pointPos = point.transform.position;
            float waveHeight = WaveManager.Instance.GetWaveHeight(pointPos.x, pointPos.z) + WaveManager.Instance.transform.position.y;
            _rb.AddForceAtPosition(Physics.gravity / floatPoints.Count, pointPos, ForceMode.Acceleration);

            if (pointPos.y < 0)
            {
                float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
                _rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), pointPos, ForceMode.Acceleration);
                _rb.AddForce(-_rb.velocity * (displacementMultiplier * waterDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);
                _rb.AddTorque(-_rb.angularVelocity * (displacementMultiplier * waterAngularDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);    
            }
        }
    }
}
