﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject FirePoint;
    GameObject enemy;
    GameObject player;
    float distance;
    float TimebetweenShots;
    float startTBS = 5f;
   




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        enemy = this.gameObject;
        TimebetweenShots = startTBS; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;


        distance = Vector3.Distance(enemy.transform.position, player.transform.position);       

        if (distance < 50)
        {              
            if(TimebetweenShots <= 0)
            {
               Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);
               TimebetweenShots = startTBS; 
            }
           else
           {
             TimebetweenShots -= Time.deltaTime;
           }
        }
    }

    
        
                     
    
}
