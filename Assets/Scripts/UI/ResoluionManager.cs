using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoluionManager : MonoBehaviour
{
    public int width = 1900;
    public int height = 1080;
    //assumes game starts windowed
    private bool fs = false;

    public void SetWidth(int newWidth) {

        width = newWidth;
    }

    public void SetHeight(int newHeight)
    {
        height = newHeight;
    }

    public void SetRes()
    {
        Screen.SetResolution(width, height, fs);
    }

    public void setFS() {
        fs = !fs;
        SetRes();
    }
}
