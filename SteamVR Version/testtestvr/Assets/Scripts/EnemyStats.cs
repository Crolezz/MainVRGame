using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private GameObject playerChar;

    public int Health;
    public float nextAttack;
    public float attackTimer;
    private float rangeToPlayer;
    public float rangeToAttack;
    private bool firstInRange = false;

    Animator anim;
    void Start()
    {
        //Health = 100;
        //nextAttack = 2f;
        //rangeToAttack = 6;
        attackTimer = nextAttack;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        playerChar = GameObject.FindGameObjectWithTag("Player");

        rangeToPlayer = Vector3.Distance(transform.position, playerChar.transform.position);

        if (rangeToPlayer < rangeToAttack)
        {
            firstInRange = true;
        }

        if (firstInRange == true)
        {
            attackTimer -= Time.deltaTime;
        }

        //Attack timer for enemy
        if (attackTimer < 0 && rangeToPlayer < rangeToAttack)
        {
            PlayerStats.Health -= 15;
            attackTimer = nextAttack;
            anim.SetBool("Bite1", true);
        }
        else
        {
            anim.SetBool("Bite1", false);
        }

        //What happens when HP reaches 0
        if (Health <= 0)
        {
            EnemySpawner.enemiesKilled++;
            Destroy(gameObject);
        }

        //Code for when the enemy is hi with a weapon goes here
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= 100;
        }
    }

    //set damage done by melee weapons and ranged weapons
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Weapon_Sword"))
        {
            Health -= 35;
        }

        if (other.gameObject.CompareTag("Player_Bullet"))
        {
            Health -= 25;
            Destroy(other.gameObject);
        }
    }
}
