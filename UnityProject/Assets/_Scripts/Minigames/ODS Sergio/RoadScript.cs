using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector3 carDir;

    [SerializeField] private float timeBeetweenSpawns;
    private float timer;
    [SerializeField] private float carSpeed;
    [SerializeField] private float distanceToDestroy;

    private GameObject go = null;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCars();
        if (timeBeetweenSpawns<timer && go == null)
        {
            Debug.Log(Time.time);
            go = Instantiate(car,spawnPoint.position,Quaternion.identity);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }


    void MoveCars()
    {
        if(go == null) { return; }
            if (Vector3.Distance(go.transform.position,spawnPoint.transform.position)> distanceToDestroy)
            {
                Destroy(go.gameObject);
                go = null;
            }
            else
            {
                go.transform.position += carDir * carSpeed * Time.deltaTime;
            }
            
    }

       
}

