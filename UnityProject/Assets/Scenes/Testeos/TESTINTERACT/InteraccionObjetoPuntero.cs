using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjetoPuntero : LInteractableParent
{
    public override void Interact()
    {
        PunteroScript scriptpuntero = GameObject.Find("Puntero").GetComponent<PunteroScript>();
        gameObject.transform.parent = scriptpuntero.transform;
        scriptpuntero.refObjetoInteract = this.gameObject;
    }
}
