using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// simple menu UI
public class MainMenu : MonoBehaviour
{

    public void PlayGame() {
        //load next scene in queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
