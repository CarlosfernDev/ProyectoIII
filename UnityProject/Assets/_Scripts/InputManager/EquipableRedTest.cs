using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableRedTest : MonoBehaviour,Iinteractable
{
    [SerializeField] private GameObject player;
    [SerializeField] private TestInputs script;
    [SerializeField] private bool _isInteractable;
    public string _TextoInteraccion;

    //Por como se implementan las interfaces se debe poner el set y get de las variables.
    //Ni idea de si hay otra manera de implementar variables de una interfaz sin poner esto.
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


    public void Interact()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<TestInputs>(); 
        transform.GetComponent<Collider>().enabled = false;
        script.hideTextFunction();


        script.isEquipado = true;
        script.refObjetoEquipado = this.transform.gameObject;
        transform.position = script.positionRed.transform.position;
        transform.localRotation = player.transform.rotation;
        transform.parent = script.positionRed.transform;
        Debug.Log("INTERACTUO CON " + transform.name + " " + _TextoInteraccion);
        SetInteractFalse();

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
