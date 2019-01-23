using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PressPlay ()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsMenu()
    {
        // Activate Settings object and disable other buttons
    }
    public void QuitPutton ()
    {
        Application.Quit();
    }

}
