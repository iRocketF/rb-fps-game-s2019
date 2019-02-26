using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioMixer audioMixer;
    public void SetVolume (float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void BackButton() {
        mainMenu.EnableChildren();
    }
}
