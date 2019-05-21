using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCountDown : MonoBehaviour
{

    public float currentTime;
    public float startTime = 4;

    public int timer;


    public Sprite count;
    public Sprite three;
    public Sprite two;
    public Sprite one;
    public Sprite go;
    bool round;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        round = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1* Time.deltaTime;

        if(currentTime == 4 && currentTime >= 3.01) {
            count = three;
        }
        if(currentTime == 3 && currentTime >= 2.01) {
            count = two;
        }
        if(currentTime == 2 && currentTime >= 1.01) {
            count = one;
        }
        if(currentTime == 1 && currentTime >= 0.01) {
            count = go;
        }
        
        if (currentTime <= 0) {
            currentTime= 0;
            round = true;
        } 
    }
}
