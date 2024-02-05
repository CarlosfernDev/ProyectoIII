using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestInputs : MonoBehaviour
{


    [SerializeField] GameObject interactZone;
    private bool isInteractable = false;
    private GameObject refObjetoInterac;

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
      
       
        
        
        if (isInteractable)
        {
            refObjetoInterac.GetComponent<Iinteractable>().Interact();
            Debug.Log("INTERACTUO");
            return;

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
                rb.velocity -= DesAccSpeed * rb.velocity;
                
               // Debug.Log(rb.velocity.magnitude);
                return;

            }
            else
            {
                rb.AddForce(new Vector3(vec.x, 0f, vec.y) * AcceSpeed, ForceMode.Acceleration);
            }
            if (rb.velocity.magnitude>maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            transform.rotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z));
        }
        /* Movimiento not sloopy
        else
        {
            if (vec.magnitude == 0)
            {
                rb.velocity = Vector3.zero;
                return;
            }
            rb.velocity = new Vector3(vec.x, 0f, vec.y) * maxSpeed;
            
        }
        */


       // Debug.Log(rb.velocity.magnitude);

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
           // Debug.Log("OBJETO INTERACTUABLE A SALIDO DE RANGO");

        }
    }

    
}
