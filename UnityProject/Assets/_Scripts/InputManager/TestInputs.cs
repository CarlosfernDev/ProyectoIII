using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestInputs : MonoBehaviour
{

  

    [SerializeField] GameObject interactZone;
    private bool isInteractable = false;
    private GameObject refObjetoInterac;
    public float speed;

    [SerializeField] private UnityEvent hideText;
    [SerializeField] private UnityEvent<string> TextoInteractChange;
    //Modificacion de la clase event para poder pasar en las llamadas strings
    [System.Serializable]
    public class MyStringEvent : UnityEvent<string>
    {
    }


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
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(vec.x, 0f, vec.y)* speed;
        //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3(vec.x+transform.position.x, 0f, vec.y+ transform.position.z), 360f, 10f));
        transform.rotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f,transform.position.z));
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable))
        {
            refObjetoInterac = other.gameObject;
            isInteractable = true;
            TextoInteractChange.Invoke(refObjetoInterac.GetComponent<Iinteractable>().TextoInteraccion);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable))
        {
            isInteractable = false;
            hideText.Invoke();
            Debug.Log("OBJETO INTERACTUABLE A SALIDO DE RANGO");

        }
    }
}
