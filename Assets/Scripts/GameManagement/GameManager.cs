using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public  static GameManager instance;

    public Transform p1;
    public Transform p2;

    public int player1Score;
    public int player2Score;

    public float gameEndTimer;

    private string winner;

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

        gameEndTimer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (player1Score == 20 || player2Score == 20)
        {
            GameEnd();
            
        }
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

    public void GameEnd()
    {
        
        Time.timeScale = 0.4f;
        gameEndTimer += Time.deltaTime;

        if(gameEndTimer > 10f)
        {
            SceneManager.LoadScene(0);
        }
        
    }
    
}
