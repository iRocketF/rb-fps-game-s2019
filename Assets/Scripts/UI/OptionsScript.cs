using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown gameModeSelect;

    public void Start()
    {
        gameModeSelect = GetComponentInChildren<Dropdown>();
        gameModeSelect.onValueChanged.AddListener(delegate
        {
            GameModeSelect(gameModeSelect.value);
        });
    }

    public void Update()
    {

    } 

    public void SetVolume (float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void BackButton() {
     SceneManager.LoadScene(0);
    }

    public void GameModeSelect(int selection)
    {
        switch(selection)
        {
            case 0:
                GameManager.instance.wins = 10;
                break;
            case 1:
                GameManager.instance.wins = 1;

                break;
            case 2:
                GameManager.instance.wins = 5;
                break;
        }
    }

  
}
