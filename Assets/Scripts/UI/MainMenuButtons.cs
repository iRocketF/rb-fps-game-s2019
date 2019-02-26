using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    
    public GameObject settings;
    public bool options;

    void Start() {
        settings.SetActive(false);
    }
    public void Play() {
        SceneManager.LoadScene(1);
    }
    public void ActiveSett() {
        DisableChildren();
        settings.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void DisableChildren()  
{    
    foreach (Transform child in transform)     
    {  
        child.gameObject.SetActive(false);   
        }   
    }
    public void EnableChildren() {
        foreach (Transform child in transform)     
    {  
        child.gameObject.SetActive(true);   
        }   
    }

    }

