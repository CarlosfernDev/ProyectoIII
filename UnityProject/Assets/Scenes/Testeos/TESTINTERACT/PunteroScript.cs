using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(1)]
public class PunteroScript : MonoBehaviour
{

    //Equipment (Red nubes fran)
    [SerializeField] public Transform positionEquipable;
    public bool isEquipado = false;
    public GameObject refObjetoEquipado;
    public bool isEquipableInCooldown;

    //Interaction
    [SerializeField] public GameObject interactZone;
    public GameObject refObjetoInteract;
    private bool isInteractable = false;



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


    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        try
        {
            InputManager.Instance.movementEvent.AddListener(MeMuevo);
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
        InputManager.Instance.interactEvent.RemoveListener(Interactuo);
    }

    public void Interactuo()
    {
        if (refObjetoInteract == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 40f))
            {
                if (hit.transform.gameObject.TryGetComponent<Iinteractable>(out Iinteractable inter))
                {
                    inter.Interact();
                }
            }
        }
        else
        {
            refObjetoInteract.transform.parent = null;
            refObjetoInteract.transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            refObjetoInteract.transform.rotation = Quaternion.Euler(90f, 0, 0);
            refObjetoInteract = null;
            

        }
       
    }
    public void MeMuevo(Vector2 vec)
    {
        var Matrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45f, 0));
        var inputChueca = Matrix.MultiplyPoint3x4(new Vector3(vec.x, 0f, vec.y));

        transform.position += new Vector3(inputChueca.x, 0, inputChueca.z);

    }





    public void hideTextFunction()
    {
        hideText.Invoke();
    }
}
