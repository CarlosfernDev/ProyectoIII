using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoEcologicoODS7 : MonoBehaviour,Iinteractable
{

    public string _TextoInteraccion;
    [SerializeField] private bool _isInteractable;
    public string TextoInteraccion
    {
        get { return _TextoInteraccion; }
        set { _TextoInteraccion = value; }
    }
    public bool IsInteractable
    {
        get { return _isInteractable; }
        set { _isInteractable = value; }
    }


    [SerializeField] private TestInputs script;
    [SerializeField] private EquipableRedTest redScript;

    public void Interact()
    {
        script = GameObject.Find("Player").GetComponent<TestInputs>();
        if (!script.isEquipado)
        {
            return;
        }
        redScript = script.refObjetoEquipado.GetComponent<EquipableRedTest>();
        if (redScript.cloudCaptured !=null)
        {
            //Llamar funcion de puntuacion?
            redScript.cloudCaptured.transform.parent = null;
            Destroy(redScript.cloudCaptured.gameObject);
            redScript.cloudCaptured = null;
            redScript._isCloudCaptured = false;
      
            script.BoostVelocidad(10f, 20f, 0.9f, 5f);
            Debug.Log("Nube en objeto");
        }
    }
    


    public void SetInteractFalse()
    {
        IsInteractable = false;
    }

    public void SetInteractTrue()
    {
        IsInteractable = true;
    }
}
