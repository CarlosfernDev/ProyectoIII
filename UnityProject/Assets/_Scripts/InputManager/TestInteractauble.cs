using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractauble : MonoBehaviour,Iinteractable
{
    public string _TextoInteraccion;

    public string TextoInteraccion
    {
        get { return _TextoInteraccion; }
        set { _TextoInteraccion = value; }
    }
    public void Interact()
    {
        Debug.Log("INTERACTUO CON " + transform.name+" "+ _TextoInteraccion);
    }
}
