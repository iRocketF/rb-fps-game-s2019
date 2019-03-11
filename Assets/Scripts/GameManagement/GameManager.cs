﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public  static GameManager instance;

    public int player1Score;
    public int player2Score;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
            
        else if (instance != this)
            Destroy(gameObject);

        player1Score = 0;
        player2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void GivePoint(int playerNum)
    {
        if (playerNum == 1)
            player2Score++;
        if (playerNum == 2)
            player1Score++;
        else
        {
            Debug.Log("Score error. Cant place point.");
        }
    }
}
