﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    private GameObject playerChar;

    public int Health;
    public float nextAttack;
    public float attackTimer;
    private float rangeToPlayer;
    public float rangeToAttack;
    void Start()
    {
        Health = 400;
        nextAttack = 3f;
        rangeToAttack = 6;
        attackTimer = nextAttack;
    }

    void Update()
    {
        playerChar = GameObject.FindGameObjectWithTag("Player");

        rangeToPlayer = Vector3.Distance(transform.position, playerChar.transform.position);

        attackTimer -= Time.deltaTime;

        //Attack timer for enemy
        if (attackTimer < 0 && rangeToPlayer < rangeToAttack)
        {
            PlayerStats.Health -= 30;
            attackTimer = nextAttack;
        }

        //What happens when HP reaches 0
        if (Health <= 0)
        {
            EnemySpawner.killedBoss = true;
            Destroy(gameObject);
        }

        //Code for when the enemy is hi with a weapon goes here
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= 100;
        }
    }
}