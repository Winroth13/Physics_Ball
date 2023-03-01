using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //The play button.
    public void PlayGame ()
    {
        //Loads in the first level.
        SceneManager.LoadScene(1);
    }

    //The quit button.
    public void QuitGame ()
    {
        //Quits the program.
        Debug.Log("Quit");
        Application.Quit();
    }
}
