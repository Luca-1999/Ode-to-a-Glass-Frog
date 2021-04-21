using UnityEngine;

//like an abstract class in Java, specifices
//states and behaviors that all of its children
//must implement; used for testing; not implemented currently
public interface IPooledIObject
{
    void OnObjectSpawn();
}
