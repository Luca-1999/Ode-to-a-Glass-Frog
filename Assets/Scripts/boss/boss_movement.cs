using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_movement : MonoBehaviour
{
    public float speed = 0.9f;
    boss_attack ba;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        ba = GetComponent<boss_attack>();
        anim = GetComponent<Animator>();
    }

    public bool move (Transform player, Rigidbody2D rb)
    {
        //TODO this
        Collider2D rangePl = ba.inRange();
        if (ba.inRange())
        {
            ba.attack(rangePl.gameObject, anim);
            return false;
            // stop movement
        }

        //path towards player
        Vector2 tgt = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, tgt, speed * Time.fixedDeltaTime);
        // use this for rigid body movement, otherwise expect unexpected behavior
        rb.MovePosition(newPos);

        //check for flip

        //TODO no need to return in range anymore
        return ba.inRange();
    }

    private void Flip()
    {

        //isRight = !isRight;
        Vector3 lScale = transform.localScale;
        lScale.x *= -1;//flip
        transform.localScale = lScale;
    }
}
