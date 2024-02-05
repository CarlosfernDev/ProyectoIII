using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TestDialogueInteract : MonoBehaviour, Iinteractable
{
    [SerializeField] private string _TextoInteraccion;

    public string TextoInteraccion
    {
        get { return _TextoInteraccion; }
        set { _TextoInteraccion = value; }
    }

    public void Interact()
    {
        DialogueRunnerSingleton.Instance.StartDialogue("CubeDialogue");
    }
}
