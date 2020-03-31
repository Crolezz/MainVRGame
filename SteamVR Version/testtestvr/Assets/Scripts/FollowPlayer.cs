using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject PlayerChar;
    NavMeshAgent agent;
    Animator anim;

    private bool isFollowing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        //Disables cursor during gameplay
        //Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        PlayerChar = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(PlayerChar.transform.position);
        transform.LookAt(new Vector3(PlayerChar.transform.position.x, transform.position.y, PlayerChar.transform.position.z));

        if (Vector3.Distance(transform.position, PlayerChar.transform.position) >= 3f)
        {
            //anim.SetFloat("InputMagnitude", 1f);
            isFollowing = true;
        }
    }
}
