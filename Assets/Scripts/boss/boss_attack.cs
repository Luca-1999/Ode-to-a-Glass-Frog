using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_attack : MonoBehaviour
{

    public float attckRange = 1f;
    public float baseDmg = 1f;
    public float attckSpeed = 1f;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        //play damage animation
        //decrement health
        //check for death
    }

    public void attack(GameObject player, Animator anim) {
        Rigidbody2D rigidBod = GetComponent<Rigidbody2D>();
        //rigidBod.constraints = RigidbodyConstraints2D.FreezeAll;

        // cancel momentum on attack
        rigidBod.velocity = Vector2.zero;
        anim.Play("Base Layer.battk1", -1, 0f);
        //rigidBod.constraints = RigidbodyConstraints2D.None;
        
        //if i can attack
        //pick random attack
    }

    public Collider2D inRange()
    {
        //Collider2D playerColl = Physics2D.OverlapCircle(this.transform.position, aggroRadius, playerLayer);
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        // position for overlap box calculated using box collider offset since we are not guaranteed
        // that the collider is precisely centered around the game object's transform coords
        Collider2D playerColl = Physics2D.OverlapBox(new Vector2 (transform.position.x + bc.offset.x,
            transform.position.y + bc.offset.y), new Vector2 (bc.size.x + attckRange, bc.size.y), 0f, playerLayer);
        return playerColl;
    }

    private void OnDrawGizmosSelected()
    {
        if (this.transform == null)
            return;
        //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        //Gizmos.DrawWireCube(new Vector3 (transform.position.x + bc.offset.x,
        //    transform.position.y + bc.offset.y, transform.position.z),
        //    new Vector3 (bc.size.x, bc.size.y, 0f));
        Gizmos.DrawWireCube(new Vector3(transform.position.x + bc.offset.x,
            transform.position.y + bc.offset.y, transform.position.z),
            new Vector3(bc.size.x + attckRange, bc.size.y, 0f));
    }
}
