using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    Transform playerTransform;
    NavMeshAgent navMesh;
    public float checkRate = 0.01f;
    float nextCheck;
       
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            Follow();
        }
    }

    void Follow()
    {
        navMesh.transform.LookAt(playerTransform);
        navMesh.destination = playerTransform.position;
    }
}
