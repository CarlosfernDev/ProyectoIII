using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestInputs : MonoBehaviour
{


    [SerializeField] GameObject interactZone;
    private bool canInteract = false;
    private GameObject refObjetoInteract;
    [SerializeField] private GameObject interactZone;
    private bool isInteractable = false;
    private GameObject refObjetoInterac;

    [SerializeField] public bool sloopyMovement;
    private Rigidbody rb;
    public float actualAcceSpeed;
    public float actualMaxSpeed;
    public float actualDesSpeed;
    public float rotationSpeed;

    private float baseAcceSpeed;
    private float baseMaxSpeed;
    private float baseDesAccSpeed;

    private IEnumerator coroutineWaparda;

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
        baseAcceSpeed = actualAcceSpeed;
        baseMaxSpeed = actualMaxSpeed;
        baseDesAccSpeed = actualDesSpeed;

}

    public void Interactuo()
    {
        if (canInteract)


        BoostVelocidad(10f, 100f, 1f, 5f);
        
        if (isInteractable)
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
                    rb.velocity -= actualDesSpeed * rb.velocity;
                }
               
                
               // Debug.Log(rb.velocity.magnitude);

            }
            else
            {
                rb.AddForce(new Vector3(vec.x, 0f, vec.y) * actualAcceSpeed, ForceMode.Acceleration);
                //RotacionPJ
                //transform.rotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z));

                

                Quaternion toRotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z));



                if (Mathf.Rad2Deg * Mathf.Abs(rb.rotation.y - toRotation.y)>45f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z));
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }
                
                

                
            }
            if (rb.velocity.magnitude>actualMaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * actualMaxSpeed;
            }
            
        }
      

    }

    public void BoostVelocidad(float velocidadMaximaNueva,float velocidadAceleracionNueva, float velocidadDesacNueva, float Tiempo)
    {
        if (coroutineWaparda != null)
        {
            StopCoroutine(coroutineWaparda);
        }
        
        coroutineWaparda = BoostVelocidadCoroutine(velocidadMaximaNueva, velocidadAceleracionNueva, velocidadDesacNueva, Tiempo);
        StartCoroutine(coroutineWaparda);
    }

    public IEnumerator BoostVelocidadCoroutine(float velocidadMaximaNueva, float velocidadAceleracionNueva,float velocidadDesacNueva, float Tiempo)
    {
        actualAcceSpeed = velocidadAceleracionNueva;
        actualMaxSpeed = velocidadMaximaNueva;
        actualDesSpeed = velocidadDesacNueva;
        yield return new WaitForSeconds(Tiempo);

        actualAcceSpeed = baseAcceSpeed;
        actualMaxSpeed = baseMaxSpeed;
        actualDesSpeed = baseDesAccSpeed;
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
            if (interactable.IsInteractable)
            {
                TextoInteractChange.Invoke(refObjetoInteract.GetComponent<Iinteractable>().TextoInteraccion);
            }
            else
            {
                hideText.Invoke();
            }
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
