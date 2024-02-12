using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoEcologicoODS7 : LInteractableParent
{
    [SerializeField] private TestInputs script;
    [SerializeField] private EquipableRedTest redScript;

    public override void Interact()
    {
        base.Interact();

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
}
