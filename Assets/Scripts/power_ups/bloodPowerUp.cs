using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// increase in max health and full heal
public class bloodPowerUp : pUpParent
{
    private pUps pUp = pUps.blood;
    public int bloodBonus;

    public void Awake()
    {
        
    }

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
        obj.GetComponent<PlayerCombat>().maxHealth += bloodBonus;
        obj.GetComponent<PlayerCombat>().fullHeal();
    }
}
