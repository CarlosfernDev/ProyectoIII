using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageScript : LInteractableParent
{
    public enum garbageType { UNDEFINED, PAPER, PLASTIC, GLASS }
    public garbageType thisGarbageType = garbageType.UNDEFINED;

    private bool isPickedUp;
    private Transform _playerPickupTransform;
    
    void Update()
    {
        if (isPickedUp)
        {
            transform.position = _playerPickupTransform.position;
        }
    }

    public override void Interact()
    {
        base.Interact();
        isPickedUp = true;
        _playerPickupTransform = ODS12Singleton.Instance.playerPickupTransform;
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }
}
