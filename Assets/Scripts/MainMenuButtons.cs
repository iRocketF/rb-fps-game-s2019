using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(1);
    }
    public void ActiveSett() {
        //Activate settings and disable other mainmenu buttons
    }

    public void QuitGame() {
        Application.Quit();
    }
}
