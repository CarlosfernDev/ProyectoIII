using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBridge : MonoBehaviour, Iinteractable
{
    [SerializeField] public bool _isInteractable;
    [SerializeField] private string _TextoInteraccion;
    [SerializeField] private int costMaterial;
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

    public void Start()
    {
        _TextoInteraccion = "Coste de construccion: " + costMaterial;
    }
    public void Interact()
    {
        if (GameManagerSergio.Instance.checkMaterial() >= costMaterial)
        {
            Debug.Log("Pago para construir puente");
            GameManagerSergio.Instance.minusMaterial(costMaterial);
            Swap();
        }
        else
        {
            Debug.Log("Necesito mas monedas");
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

    public void Swap()
    {
        GameManager.Instance.playerScript.hideTextFunction();
        
        Destroy(this.gameObject);
    }
}
