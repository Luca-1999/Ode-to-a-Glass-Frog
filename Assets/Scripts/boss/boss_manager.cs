using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_manager : MonoBehaviour
{

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

    public void checkActivate ()
    {
        //checks if player has all power ups
        //transitions into next state if yes
    }

    public void die() {

        //play death animation
        Destroy(gameObject);
    }
}
