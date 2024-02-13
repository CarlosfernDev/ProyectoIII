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
    [SerializeField] public bool isReturningToFactory = false;
    [SerializeField] public bool isStandBY = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveNewDirection();
    }
    private void Update()
    {
        if (isStandBY)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        if (isReturningToFactory)
        {
            rb.velocity = (posFactory.position- this.transform.position).normalized*speed;
            transform.LookAt(posFactory);
            return;
        }

        rb.velocity = transform.forward * speed;

    }

    void getRandomDir()
    {
        vecMovementDir = new Vector3(0, Random.Range(0, 360), 0);
    }
    void setRotation(Vector3 vec)
    {
        transform.rotation = Quaternion.Euler(vec);
    }

    void moveNewDirection()
    {
        getRandomDir();
        setRotation(vecMovementDir);
    }

  

    private void OnCollisionStay(Collision collision)
    {

        //Funcion de detectar cosas con lo que rebotar, deben tener la misma layer
        Debug.Log(collision.gameObject.layer + "////" + ToLayer(layer));
        if (collision.gameObject.layer == ToLayer(layer))
        {
           
            moveNewDirection();
        }

        if (TryGetComponent<CloudSpawner>(out CloudSpawner cloud))
        {
            Debug.Log("FACTORY DETECTED");
            isReturningToFactory = false;
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

    public void WEGOINGTOFACTORYYYYYYYYBOYSSS(Transform _posFactory)
    {
        posFactory = _posFactory;
        isReturningToFactory = true;
    }
}
