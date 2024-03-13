using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Compiler;

[DefaultExecutionOrder(1)]
public class MovementSergio : MonoBehaviour
{

    //Equipment (Red nubes fran)
    [SerializeField] public Transform positionEquipable;
    public bool isEquipado = false;
    public GameObject refObjetoEquipado;
    public bool isEquipableInCooldown;

    //Interaction
    [SerializeField] public GameObject interactZone;
    private GameObject refObjetoInteract;
    private bool isInteractable = false;



    //Movement
    private Rigidbody rb;
    private float grav;
    public float Speed;
    
    public float rotationSpeed;

   

    //Actualizador de UI? maybe hay que moverlo a los scripts interactuables y hacer que los objetos busquen la ui en la escena
    [SerializeField] private UnityEvent hideText;
    [SerializeField] private UnityEvent<string> TextoInteractChange;
    //Modificacion de la clase event para poder pasar en las llamadas strings
    [System.Serializable]
    public class MyStringEvent : UnityEvent<string>
    {
    }

    public void Awake()
    {
        //rb = transform.GetComponent<Rigidbody>();
        

    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        try
        {
            InputManager.Instance.movementEvent.AddListener(MeMuevo);
            InputManager.Instance.equipableEvent.AddListener(UsarObjetoEquipable);
            InputManager.Instance.interactEvent.AddListener(Interactuo);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            Debug.LogWarning("No se pudo asignar los eventos, probablemente te faltara un InputManager");
        }
    }

    private void OnDisable()
    {
        InputManager.Instance.movementEvent.RemoveListener(MeMuevo);
        InputManager.Instance.equipableEvent.RemoveListener(UsarObjetoEquipable);
        InputManager.Instance.interactEvent.RemoveListener(Interactuo);
    }

    public void Interactuo()
    {
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
        //  Comento la linea por que si no el char controller no va en la escena de inputtest
        // if (GameManager.Instance.isDialogueActive && (MySceneManager.Instance == null ? MySceneManager.Instance.isLoading : false) && (GameManager.Instance == null ? GameManager.Instance.isPaused : false)) return;
        
                //Rotation
                if (new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z) != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z));
                    if (Mathf.Rad2Deg * Mathf.Abs(transform.rotation.y - toRotation.y) > 45f)
                    {
                        transform.rotation = Quaternion.LookRotation(new Vector3(vec.x + transform.position.x, 0f, vec.y + transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z));
                    }
                    else
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                    }
                }
                //Movement con gravedad
                RaycastHit[] hit;
                grav = 0f;
                bool ground = false;
                hit = Physics.RaycastAll(transform.position, Vector3.down, 1.1f);

                foreach (var item in hit)
                {
                    if (ground == true)
                    {
                        break;
                    }
                    if (item.collider.gameObject.tag == "Ground")
                    {
                        grav = 0f;
                        ground = true;
                    }
                    else
                    {
                        ground = false;
                        grav = -9.8f;
                    }
                }
               
        transform.position += new Vector3(vec.x, grav, vec.y).normalized*Speed*Time.deltaTime;
        ground = false;
     }


        

    

 



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable))
        {
            if (interactable.IsInteractable)
            {
                refObjetoInteract = other.gameObject;
                isInteractable = true;
                TextoInteractChange.Invoke(other.GetComponent<Iinteractable>().TextoInteraccion);
            }

        }

    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Iinteractable>(out Iinteractable interactable) && refObjetoInteract == other.gameObject)
        {
            refObjetoInteract = null;
            isInteractable = false;
            hideTextFunction();

        }
    }


    public void UsarObjetoEquipable()
    {

        if (isEquipado)
        {
            //Llamo a la funcion que deben implementar todos los objetos equipables.
            refObjetoEquipado.GetComponent<Iequipable>().UseEquipment();

            Debug.Log("Uso objeto" + refObjetoEquipado.name);
        }
        else
        {
            Debug.Log("OBJETO NO EQUIPADO");
        }
    }


    public void hideTextFunction()
    {
        hideText.Invoke();
    }
}

