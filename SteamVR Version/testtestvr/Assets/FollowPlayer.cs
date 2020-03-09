using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    Animator animator;
    Transform playerTransform;
    Transform zlorpTransform;
    NavMeshAgent navMesh;
    public float checkRate = 0.01f;
    float nextCheck;
    public float walkSpeed = 14;
    public float runSpeed = 20;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        zlorpTransform = GameObject.FindGameObjectWithTag("Zlorp").transform;
       // navMesh = gameObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //CalculateDistance();
       // Animations();


        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            Follow();
        }

    }

    void Follow()
    {
      //  navMesh.transform.LookAt(playerTransform);
       // navMesh.destination = playerTransform.position;
    }

    void Animations()
    {

      /*  if (navMesh.speed >= 16 && navMesh.speed > 15)
        {
            animator.SetFloat("InputMagnitude", 0.5f);
        }
        else if (navMesh.speed < 15 && navMesh.speed > 0)
        {
            animator.SetFloat("InputMagnitude", 0.5f);
        }
        else if (navMesh.speed <= 0)
        {
            animator.SetFloat("InputMagnitude", 0.5f);
        }
        */
    }

    void CalculateDistance()
    {

        float dist = Vector3.Distance(zlorpTransform.position, playerTransform.position);
        //Debug.Log("The distance is.................." + dist);

        if (dist >= 200)
        {
            navMesh.speed = 0;
        }
        else if (dist >= 151 && dist < 200)
        {
            navMesh.speed = walkSpeed;
        }
        else if (dist <= 150 && dist >= 11)
        {
            navMesh.speed = runSpeed;
        }
        else
        {
            navMesh.speed = 0;
        }
    }
}
