using UnityEngine;

public class pUpParent : MonoBehaviour
{

    public enum pUps
    {
        mass, soul, blood,
    }

    public pUps pUp;
    public int bloodBonus;//health
    public int soulBonus;//damage


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            Debug.Log("Collided with player");
            onPickup(obj);
            Destroy(gameObject);
        }
    }

    void onPickup(GameObject obj)
    {
        switch (pUp) {
            case pUps.mass:
                obj.GetComponent<playerMovement>().dJump = true;
                break;
            case pUps.soul:
                obj.GetComponent<PlayerCombat>().attckDamage += soulBonus;
                break;
            case pUps.blood:
                obj.GetComponent<PlayerCombat>().maxHealth += bloodBonus;
                obj.GetComponent<PlayerCombat>().fullHeal();
                break;
        }
    }

}
