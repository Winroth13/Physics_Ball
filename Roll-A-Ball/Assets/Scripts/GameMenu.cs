using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    //The restart button.
    public void Restart ()
    {
        //Reloads the first level.
        SceneManager.LoadScene(1);
    }

    //The main menu button.
    public void MainMenu ()
    {
        //Loads in the mein menu.
        SceneManager.LoadScene(0);
    }

    //The continue button.
    public void Continue ()
    {
        //Shows cursor.
        Cursor.visible = false;
    }
}
