using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (AudioManager.instance.IsPlaying("sound_music_menu"))
        {
            AudioManager.instance.StopSound("sound_music_menu");
        }

        AudioManager.instance.PlaySound("sound_music_menu");

    }
    public void Play() {
        SceneManager.LoadScene(2);
        if (AudioManager.instance.IsPlaying("sound_music_menu"))
        {
            AudioManager.instance.StopSound("sound_music_menu");
        }
    }

    public void Options() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

}

