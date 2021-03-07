using System.Collections;
using System.Collections.Generic;//needed for dictionary and pool
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    //can store reference to PoolTest in variable,
        //initialized on start
    //to use: PoolTest.Instance.SpawnFromPool(...);
        //Quaternion.identity

    //what goes in the dictionary
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static PoolTest instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    //dictionary of tag and queues; when instantiating new object
    //simply grab the first in the queue

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //adding list of pools to dictionary
        //each pool matches with a specified queue
        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //poopulate pool queue with specified number of
            //objects in current pool
            for (int i = 0; i < pool.size; i++)
            {
                //instantiate object specified by chosen prefab
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    //unsure wether to use vector3 or vector2
    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't" +
                "exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        //IPooledIObject pooledObj = objectToSpawn.GetComponent<IPooledIObject>();
        //if (pooledObj != null)
        //{
        //    pooledObj.OnObjectSpawn();
        //}

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

}

//extra notes: if object to be instantiated has behavior
    //dependent on start funciton, it will only be triggered
    //a single time, so we can design a "home-made" start method
    //by using an interface; script with spawn behavior in
    //specified object can be made to derive from interface as well;
    //CHANGE start to onObjectSpawn
