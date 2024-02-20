using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableMateriales : MonoBehaviour, Iinteractable
{
    [SerializeField] GameObject scriptGameobject;
    [SerializeField] private bool _isInteractable;
    [SerializeField] private string _TextoInteraccion;
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
        //Sumar a materiales
    }

    public void SetInteractFalse()
    {
        IsInteractable = false;
    }

    public void SetInteractTrue()
    {
        IsInteractable = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        //Buscar refrencia de donde se guarda el script de materiales
        UItext = GameObject.Find("UIMATERIAL");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
