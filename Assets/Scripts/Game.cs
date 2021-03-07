using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for scene load
using UnityEngine.UI;// used for UI, not sure if will be necessary
    //yet

public class Game : MonoBehaviour
{

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

        //spawnPlayer("spawn1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //must somehow check if player is already on map
    public GameObject spawnPlayer(string s) {

        GameObject obj = Instantiate(player, GameObject.FindGameObjectWithTag(s).transform.position, Quaternion.identity);
        playerScript sc = obj.GetComponent<playerScript>();
        return obj;
    }
}
