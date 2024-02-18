using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GarbageCollectionPoint : MonoBehaviour
{
    public enum collectorType { UNDEFINED, PAPER, PLASTIC, GLASS }
    public collectorType thisCollectorType = collectorType.UNDEFINED;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out GarbageScript thisGarbage)) return;
        if (thisGarbage.thisGarbageType.ToString() == thisCollectorType.ToString())
        {
            //TODO: Add points
            ODS12Singleton.Instance.OnGarbageDelivered.Invoke();
            Destroy(thisGarbage.gameObject);
        }
        else
        {
            //TODO: Subtract points, subtract time
            ODS12Singleton.Instance.OnGarbageDelivered.Invoke();
            Destroy(thisGarbage.gameObject);
        }
    }
}
