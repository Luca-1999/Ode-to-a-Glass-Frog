﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 200;
    private int currentHealth;
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attckDamage = 10;
    public float attackRate = 1f; //attack per second
    float nextAttackTime = 0f;
    CharacterController2D cc2d;
    private bool airAttck = false;
    public AudioSource aS;
    private audioC audioCont;


    //tentative box collider
    public Transform attackPointA;
    public Transform attackPointB;

    private void Awake()
    {
        audioCont = audioC.instance;
    }

    private void Start()
    {
        //pass script to cc2d by reference
        cc2d = GetComponent<CharacterController2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            //check if grounded,
                //if not issue jump interrupt, attack, and queue up fall   
            //if not then proceed as usual

            if (Input.GetKeyDown(KeyCode.Space)) {
                //check if grounded
                if (!cc2d.isGrounded)
                {
                    //if so, interrupt jump animation
                    anim.SetBool("IsJumping", false);
                    airAttck = true;
                }
                //Debug.Log("attacking with airAttc = " + airAttck);
                
                //attack animation
                anim.SetTrigger("Attack");
                audioCont.Play(audioC.Sounds.aSound);
                //Attack(); unsure, might be frustrating
                nextAttackTime = Time.time + 1f / attackRate;
                //if (airAttck) anim.SetBool("IsFall", true);
                //airAttck = false;
            }
        }
    }

    public void fullHeal()
    {
        currentHealth = maxHealth;
    }

    void Attack()
    {
        Debug.Log("attack function called");

        //detect enemies in range
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(attackPointA.position, attackPointB.position, enemyLayers);

        //apply damage to all enemies hit
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("enemy hit");
            enemy.GetComponent<Enemy>().TakeDamage(attckDamage);
        }
        //anim.SetBool("Attack", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }

    public void TakeDamage(int damage) {

        //play damage sound
        audioCont.Play(audioC.Sounds.pDamage);
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("you are dead");
    }

}