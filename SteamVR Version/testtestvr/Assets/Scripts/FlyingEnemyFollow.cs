using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class FlyingEnemyFollow : MonoBehaviour
{
    public GameObject PlayerChar;
    GameObject Target;
    private NavMeshAgent nma;
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        nma = this.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("MainCamera"); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerChar = GameObject.FindGameObjectWithTag("Player");
        nma.SetDestination(PlayerChar.transform.position);
        transform.LookAt(new Vector3(PlayerChar.transform.position.x, transform.position.y, PlayerChar.transform.position.z));


        if (Health <= 0)
        {
            EnemySpawner.enemiesKilled++;
            Destroy(gameObject);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= 50;
        }
    }
}
