using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Transform playerPosition;
    Vector3 target;
    public float speed; 


    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("MainCamera").transform;
        target = new Vector3(playerPosition.position.x, playerPosition.position.y, playerPosition.position.z);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            Destroy(gameObject);
        }

    }
}
