using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    Inputs playerInputs;
    public static InputManager Instance;

    [SerializeField] private UnityEvent interactEvent;
    [SerializeField] private UnityEvent<Vector2> movementEvent;



    //Modificacion de la clase event para poder pasar en las llamadas vector2
    [System.Serializable]
    public class MyVector2Event : UnityEvent<Vector2>
    {
    }


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerInputs = new Inputs();
        playerInputs.ActionMap1.Enable();
        playerInputs.ActionMap1.Interact.performed += Interact_performed; ;
        
    }

    private void Update()
    {
        //En el caso del input Movement, no podemos usar un performed, por que al mantener la tecla no se actualizaria
        //la llamada, es mejor llamarlo cada frame y comprobar si a habido cambios en el vector
        
        movement();
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        interactEvent.Invoke();

    }

    void movement()
    {
        Vector2 vec = playerInputs.ActionMap1.Movement.ReadValue<Vector2>();
        movementEvent.Invoke(vec);


    }


}
