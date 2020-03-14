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
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            Follow();
        }

        Animations();
    }

    void Follow()
    {
        navMesh.transform.LookAt(playerTransform);
        navMesh.destination = playerTransform.position;
    }

    void Animations()
    {
        if(navMesh.speed > 0)
        {
            Anim.SetBool("Run", true);
        }
    }
}
