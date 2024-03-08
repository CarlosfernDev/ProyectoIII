using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : LInteractableParent
{
    [SerializeField] private GameObject interactObj;
    
    public override void Interact()
    {
        base.Interact();
    }
}
