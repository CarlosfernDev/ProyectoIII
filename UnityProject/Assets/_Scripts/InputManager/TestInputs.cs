using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputs : MonoBehaviour
{
   public void Interactuo()
    {
        Debug.Log("INTERACTUO");
    }
    public void MeMuevo(Vector2 vec)
    {
        if (vec.magnitude == 0)
        {
            return;
        }
        Debug.Log("MOVE: "+ vec);
    }
}
