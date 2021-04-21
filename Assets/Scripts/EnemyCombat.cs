using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator anim;
    // need to make sure it rotates
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask player;
    public int attkDamage = 2;
    public float attackRate = 1f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        //check if able to attack
        if (Time.time >= nextAttackTime) {
            if (attack()) {
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    bool attack() {

        //set attack animation at appropriate vector
        Collider2D playerColl = Physics2D.OverlapCircle(attackPoint.position, attackRange, player);
        //get player script and apply damage
        if (playerColl != null) {
            anim.SetTrigger("Attack");
            Debug.Log("enemy hit player");
            playerColl.GetComponent<PlayerCombat>().TakeDamage(attkDamage);
        }
        return playerColl;
    }

    bool inRange()
    {
        Collider2D playerColl = Physics2D.OverlapCircle(attackPoint.position, attackRange, player);
        return playerColl != null;
    }

    // draw attack range
    private void OnDrawGizmosSelected()
    {
        if (this.transform == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
