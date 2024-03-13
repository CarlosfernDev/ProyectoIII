using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            
            other.gameObject.transform.root.parent = this.gameObject.transform;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.transform.parent.parent = null;
        }
    }
}
