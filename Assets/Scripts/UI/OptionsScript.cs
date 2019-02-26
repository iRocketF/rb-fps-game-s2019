using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume (float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void BackButton() {
     SceneManager.LoadScene(1);
    }
}
