using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    bool isPaused;
    void Start()
    {
        isPaused = true;
       //Default deactivate all children of this gameObject at the start of the game
    }

    void Update()
    {
        
        if(Input.GetKeyDown("Escape") && !isPaused) {
            Time.timeScale = 0;
            //Activate all children under this gameobject
            isPaused = true;
        }
        else if (Input.GetKeyDown("Escape") && isPaused) {   
            UnPause();   
        }
    }
    public void UnPause () {
        Time.timeScale = 1;
        //Deactivate all children under this gameobject
        isPaused = false;
    }
}
