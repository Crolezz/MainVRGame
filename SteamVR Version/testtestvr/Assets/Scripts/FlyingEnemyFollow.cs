using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class FlyingEnemyFollow : MonoBehaviour
{
    public GameObject PlayerChar;
    Vector3 Target;
    private NavMeshAgent nma;
    public int Health;
    public Collider MovementZoneCollider;
    GameObject MovementZone;
    
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    void FindTarget ()
    {
        Debug.Log(RandomPointInBounds(MovementZoneCollider.bounds));
        Target = RandomPointInBounds(MovementZoneCollider.bounds);
        //nma.SetDestination(Target);
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        nma = this.GetComponent<NavMeshAgent>();
        //Target = GameObject.FindGameObjectWithTag("MainCamera");
        MovementZone = GameObject.FindGameObjectWithTag("FlyingEnemyMovementZone");
        MovementZoneCollider = MovementZone.GetComponent<Collider>();
        InvokeRepeating("FindTarget", 0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerChar = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(new Vector3(PlayerChar.transform.position.x, PlayerChar.transform.position.y, PlayerChar.transform.position.z));
        
        float step = 5.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target, step);

        //if (nma.baseOffset > Target.y)
        //{
        //    nma.baseOffset = Mathf.Lerp(Target.y, nma.baseOffset, 0.0001f);
        //}

        //if (nma.baseOffset < Target.y)
        //{
        //    nma.baseOffset = Mathf.Lerp(nma.baseOffset,Target.y, 0.1f);
        //}
        

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
