using UnityEngine;

// could be implemented as an interface so we guarantee the existence and functionality of
// getType() as inteneded but then we would need to define pUps for each new power up class,
// or we can simply make this a base class, which we do here. An alternative would be to have a power up
// interface inherit from some other class with access to this enum such as the game manager perhaps,
// but this dpenedicy might not make much sense from a design perspective

public class pUpParent : MonoBehaviour
{

    public enum pUps
    {
        mass, soul, blood,
    }

    pUps getType() {

        return pUps.blood;
    }

    // now closed to the addition of new power ups; simply have it inherit from this class
    void onPickup(GameObject obj)
    {
    }

}
