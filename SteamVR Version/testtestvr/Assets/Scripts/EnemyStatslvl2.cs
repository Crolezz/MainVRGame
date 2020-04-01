using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatslvl2 : MonoBehaviour
{
    private GameObject playerChar;
    public Slider SliderHP;

    public int Health;
    public float nextAttack;
    public float attackTimer;
    private float rangeToPlayer;
    public float rangeToAttack;
    public int damageDoneToPlayer;
    public int meleeDamageReceived;
    public int rangedDamageReceived;
    private bool firstInRange = false;

    Animator anim;
    void Start()
    {
        //Health = 100;
        //nextAttack = 2f;
        //rangeToAttack = 6;
        attackTimer = nextAttack;
      
        anim = GetComponent<Animator>();
        SliderHP = GetComponentInChildren<Slider>();

        SliderHP.maxValue = Health;
        SliderHP.value = Health;
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
            PlayerStats.Health -= damageDoneToPlayer;
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
            Health -= 200;
        }
    }

    //set damage done by melee weapons and ranged weapons
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Weapon_Sword"))
        {
            Health -= meleeDamageReceived;
            SliderHP.value -= meleeDamageReceived;
        }

        if (other.gameObject.CompareTag("Player_Bullet"))
        {
            Health -= rangedDamageReceived;
            SliderHP.value -= rangedDamageReceived;
            Destroy(other.gameObject);
        }
    }
}
