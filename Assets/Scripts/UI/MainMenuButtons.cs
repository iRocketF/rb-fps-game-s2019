using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(0);
    }

    public void Options() {
        SceneManager.LoadScene(2);
    }

    public void QuitGame() {
        Application.Quit();
    }
}

