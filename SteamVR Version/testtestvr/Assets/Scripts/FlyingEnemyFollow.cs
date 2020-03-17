using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class FlyingEnemyFollow : MonoBehaviour
{
    GameObject Target;
    private NavMeshAgent nma; 

    // Start is called before the first frame update
    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("MainCamera"); 
    }

    // Update is called once per frame
    void Update()
    {        
        nma.SetDestination(Target.transform.position);    
    }
}
