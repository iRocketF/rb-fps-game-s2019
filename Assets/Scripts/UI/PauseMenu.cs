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
    void Start()
    {
        pauseUI.SetActive(false);
    }
    void Update()
    {
        if(Input.GetButtonDown("GamePad_Pause1")) {
            
            if (isPaused) {
                Resume ();
            } else {
                Pause();
            }
        }
        /* if(Input.GetButtonDown("GamePad2_Pause")) {
            
            if (isPaused) {
                Resume ();
            } else {
                Pause();
            }
        }*/
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
        Time.timeScale = 1f;
        GameManager.instance.player1Score = 0;
        GameManager.instance.player2Score = 0;

        SceneManager.LoadScene("MainMenu");
    }
}
