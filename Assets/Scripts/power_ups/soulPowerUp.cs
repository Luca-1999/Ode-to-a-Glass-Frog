using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra damage!
public class soulPowerUp : pUpParent
{
    private pUps pUp = pUps.soul;
    public int soulBonus;

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

    void onPickup(GameObject obj)
    {
        obj.GetComponent<PlayerCombat>().attckDamage += soulBonus;
    }
}


