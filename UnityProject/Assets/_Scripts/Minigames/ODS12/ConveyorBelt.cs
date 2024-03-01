using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed, conveyorSpeed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private List<GameObject> onBelt;

    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void OnCollisionStay(Collision other)
    {
        Vector3 movement = speed * transform.forward * Time.deltaTime;
        other.gameObject.GetComponent<Rigidbody>().MovePosition(other.gameObject.transform.position + movement);
    }

    /*private void FixedUpdate()
    {
        for (int i = 0; i <= onBelt.Count; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().AddForce(speed * direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
    }*/
}
