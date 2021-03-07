using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1920*1080
        Screen.SetResolution(1920, 1080, true);
    }
}
