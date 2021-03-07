using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //public Animator anim;
    public int maxHealth = 100;
    private int currentHealth;
    public AudioClip dC;
    public GameObject aCont;
    private audioC controller;
    
    void Awake()
    {
        currentHealth = maxHealth;
        controller = aCont.GetComponent<audioC>();
    }

    private void Start()
    {
        //Die();
    }

    public void TakeDamage(int damage) {

        currentHealth -= damage;
        //hurt animation?
        //anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() {

        //controller.Play(audioC.Sounds.bDeath);
        //controller.Play(audioC.Sounds.bDeath, this.transform.position, "enemySFX");
        audioC.instance.Play(audioC.Sounds.bDeath, this.transform.position, "enemySFX");
        Debug.Log(currentHealth);
        //die anim?
        //anim.SetBool("IsDead",true);
        //disable enemy

        Destroy(gameObject);
    }
}
