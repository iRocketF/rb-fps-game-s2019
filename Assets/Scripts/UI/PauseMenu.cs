using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;
    public GameObject settarit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("GamePad_Pause")) {
            if (isPaused) {
                Resume ();
            } else {
                Pause();
            }
        }
    }
    public void Resume () {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause () {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Settarit () {
        settarit.SetActive(true);
    }

    public void ToMenu () {
        SceneManager.LoadScene("MainMenu");
    }
}
