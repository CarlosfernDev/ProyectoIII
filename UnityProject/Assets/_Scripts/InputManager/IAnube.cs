using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAnube : MonoBehaviour
{
    [SerializeField] private Transform posFactory;
    [SerializeField] private Vector3 vecMovementDir;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask layer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveNewDirection();
    }
    private void Update()
    {
        rb.velocity = transform.forward*speed;
    }

    void getRandomDir()
    {
        vecMovementDir = new Vector3(0, Random.Range(0, 360), 0);
    }
    void setRotation()
    {
        transform.rotation = Quaternion.Euler(vecMovementDir);
    }

    void moveNewDirection()
    {
        getRandomDir();
        setRotation();
    }

  

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.layer + "////" + ToLayer(layer));
        if (collision.gameObject.layer == ToLayer(layer))
        {
            Debug.Log("rarw");
            moveNewDirection();
        }
    }

    public static int ToLayer(int bitmask)
    {
        int result = bitmask > 0 ? 0 : 31;
        while (bitmask > 1)
        {
            bitmask = bitmask >> 1;
            result++;
        }
        return result;
    }
}
