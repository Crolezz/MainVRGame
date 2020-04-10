using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JeffEnemyBehavior : MonoBehaviour
{
    public Transform navmeshTarget;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(navmeshTarget.position);
    }

    void ApplyDamage()
    {
        agent.isStopped = true;
        GetComponent<Animator>().SetBool("Dead", true);
        Invoke("DestroyThis", 2);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
