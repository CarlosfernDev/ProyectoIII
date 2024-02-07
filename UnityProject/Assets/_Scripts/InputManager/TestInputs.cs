using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestInputs : MonoBehaviour
{


    [SerializeField] GameObject interactZone;
    private bool canInteract = false;
    private GameObject refObjetoInteract;

    [SerializeField] bool sloopyMovement;
    private Rigidbody rb;
    public float AcceSpeed;
    public float maxSpeed;
    public float DesAccSpeed;

    [SerializeField] private UnityEvent hideText;
    [SerializeField] private UnityEvent<string> TextoInteractChange;
    //Modificacion de la clase event para poder pasar en las llamadas strings
    [System.Serializable]
    public class MyStringEvent : UnityEvent<string>
    {
    }

    public void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    public void Interactuo()
    {
        if (canInteract)
        {
            refObjetoInteract.GetComponent<Iinteractable>().Interact();
            Debug.Log("INTERACTUO");
        }
        else
        {
            Debug.Log("NO PUEDO INTERACTUAR");
        }
    }
    public void MeMuevo(Vector2 vec)
    {
        if (sloopyMovement)
        {
            if (vec.magnitude == 0)
            {
                if (rb.velocity.magnitude<0.1f)
                {
                    rb.velocity = Vector3.zero;
                }
                else
                {
                    rb.velocity -= DesAccSpeed * rb.velocity;
                }
               
                
               // Debug.Log(rb.velocity.magnitude);

            }
            else
            {
                rb.AddForce(new Vector3(vec.x, 0f, vec.y) * AcceSpeed, ForceMode.Acceleration);
                transform.rotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z));
            }
            if (rb.velocity.magnitude>maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            
        }
      

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable) && !refObjetoInteract)
        {
            refObjetoInteract = other.gameObject;
            canInteract = true;
            TextoInteractChange.Invoke(refObjetoInteract.GetComponent<Iinteractable>().TextoInteraccion);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable) && refObjetoInteract)
        {
            if (interactable.IsInteractable) return;
            hideText.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable) && refObjetoInteract == other.gameObject)
        {
            refObjetoInteract = null;
            canInteract = false;
            hideText.Invoke();
           // Debug.Log("OBJETO INTERACTUABLE A SALIDO DE RANGO");

        }
    }

    
}
