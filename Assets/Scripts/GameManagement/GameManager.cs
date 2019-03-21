using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform p1;
    public Transform p2;

    public int player1Score;
    public int player2Score;
    public int wins;

    public float gameEndTimer;

    public bool p1_win = false;
    public bool p2_win = false;

    public P1_Hud p1Hud;
    public P2_Hud p2Hud;


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

        p2_win = false;

        gameEndTimer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (player1Score == wins || player2Score == wins)
        {
            if(player1Score == wins)
            {
                p1_win = true;
                p1Hud.WinnerText();
            }
            else if (player2Score == wins)
            {
                p2_win = true;
                p2Hud.WinnerText();
            }
            Winner();
        }

        if (p2_win)
        {
            GameEnd();
        }
    }

    public void GivePoint(int playerNum)
    {

        //AudioManager.instance.PlaySound("sound_game_pointCheer");
        if (playerNum == 1)
            player2Score++;
        if (playerNum == 2)
            player1Score++;
        else
        {

        }
    }

    public void Winner()
    {
        AudioManager.instance.PlaySound("sound_game_win");
        player1Score = 0;
        player2Score = 0;

    }

    public void GameEnd()
    {
        gameEndTimer += Time.deltaTime;

        if (gameEndTimer > 10f)
        {
            SceneManager.LoadScene(0);
            gameEndTimer = 0;
            p2_win = false;
            
        }

    }
    


}
