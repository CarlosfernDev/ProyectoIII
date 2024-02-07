using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractauble : MonoBehaviour,Iinteractable
{
    public string _TextoInteraccion;

    //Por como se implementan las interfaces se debe poner el set y get de las variables.
    //Ni idea de si hay otra manera de implementar variables de una interfaz sin poner esto.
    public string TextoInteraccion
    {
        get { return _TextoInteraccion; }
        set { _TextoInteraccion = value; }
    }
    public void Interact()
    {
        Debug.Log("INTERACTUO CON " + transform.name+" "+ _TextoInteraccion);
        transform.GetComponent<MeshRenderer>().enabled = false;
        
    }
}
