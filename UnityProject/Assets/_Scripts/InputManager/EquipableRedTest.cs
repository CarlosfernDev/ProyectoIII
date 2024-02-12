using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableRedTest : MonoBehaviour,Iinteractable,Iequipable
{
    [SerializeField] private GameObject player;
    [SerializeField] private TestInputs script;
    [SerializeField] private Transform insideRed;
    [SerializeField] private bool _isInteractable;
    [SerializeField] public bool _isCloudCaptured = false;
    [SerializeField] public GameObject cloudCaptured;
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
        //Si el objeto ya a sido interactuado no hacemos nada
        if (!_isInteractable)
        {
            return;
        }


        player = GameObject.Find("Player");
        script = player.GetComponent<TestInputs>();
        transform.GetComponent<Collider>().enabled = false;
        
        //Refs en char controller
        script.isEquipado = true;
        script.refObjetoEquipado = transform.gameObject;

        //pos y rot seteadas 
        transform.position = script.positionEquipable.transform.position;
        transform.parent = script.positionEquipable.transform;
        transform.rotation = script.positionEquipable.rotation;

        
        SetInteractFalse();
        //Maybe hacer la ui estatica o un singleton que la maneje, es un coñazo tener que llamar asi
        script.hideTextFunction();

    }

    public void UseEquipment()
    {
        StartCoroutine(AccionUsarRed());
      
    }

    IEnumerator AccionUsarRed()
    {
        if (script.isEquipableInCooldown == true)
        {
            Debug.Log("Estoy en cooldown PLAP PLAP PLAP");
            yield break;
        }
        if (_isCloudCaptured)
        {
            Debug.Log("Red Llena");
            yield break;
        }
        Debug.Log("HE SIDO USADO");
        script.isEquipableInCooldown = true;
        //Do shit
        transform.localRotation = Quaternion.Euler(90, 0, 0);

        Collider[] hitColliders = Physics.OverlapSphere(script.interactZone.transform.position, 1f);
        
        foreach (var item in hitColliders)
        {
            if (item.gameObject.tag == "Nube")
            {
                if (_isCloudCaptured == false)
                {
                    _isCloudCaptured = true;
                    item.gameObject.transform.parent = this.transform;
                    item.gameObject.transform.position = insideRed.position;
                    item.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    cloudCaptured = item.gameObject;

                }
                
            }
        }
        yield return new WaitForSeconds(0.5f);

        transform.localRotation = Quaternion.Euler(0, 0, 0);
        script.isEquipableInCooldown = false;



    }

    public void SetInteractFalse()
    {
        IsInteractable = false;
    }

    public void SetInteractTrue()
    {
        IsInteractable = true;
    }

    void OnDrawGizmos()
    {
        if(script == null) 
        {
            return; 
        }
        else 
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(script.interactZone.transform.position, 1f);
        }
        
        
    }
}



