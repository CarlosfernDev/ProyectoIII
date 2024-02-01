using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputs : MonoBehaviour
{
    [SerializeField] GameObject interactZone;
    private bool isInteractable = false;
    private GameObject refObjetoInterac;
    
   public void Interactuo()
    {
        if (isInteractable)
        {
            refObjetoInterac.GetComponent<Iinteractable>().Interact();
            Debug.Log("INTERACTUO");

        }
        else
        {
            Debug.Log("NO PUEDO INTERACTUAR");

        }
        
    }
    public void MeMuevo(Vector2 vec)
    {
        if (vec.magnitude == 0)
        {
            return;
        }
        Debug.Log("MOVE: "+ vec);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable))
        {
            refObjetoInterac = other.gameObject;
            isInteractable = true;
            Debug.Log(refObjetoInterac.GetComponent<Iinteractable>().TextoInteraccion);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable))
        {
            isInteractable = false;
            Debug.Log("OBJETO INTERACTUABLE A SALIDO DE RANGO");

        }
    }
}
