using UnityEngine;

public class pUpParent : MonoBehaviour
{

    public enum pUps
    {
        mass, soul, blood,
    }

    //public int bloodBonus;
    //public int soulBonus;//damage

    pUps getType() {

        return pUps.blood;
    }

    //Uhhhh not closed to the addition of new power ups
    void onPickup(GameObject obj)
    {
    }

}
