using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// one extra jump!
public class massPowerUp : pUpParent
{
    private pUps pUp = pUps.mass;

    public pUps getType()
    {
        return pUp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            Debug.Log("Collided with player");
            onPickup(obj);
            Destroy(gameObject);
        }
    }

    void onPickup(GameObject obj) {
        obj.GetComponent<CharInputManager>().dJump = true;
    }
}
