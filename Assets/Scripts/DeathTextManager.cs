using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTextManager : MonoBehaviour {

    Text gameOverScore;
    GameMaster gameMaster;
    ScoreManager scoreManager;

    private int highScoreToDisplay;


    // Use this for initialization
    void Start()
    {
        gameOverScore = GetComponent<Text>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        scoreManager = gameMaster.GetComponent<ScoreManager>();

        CheckIfNewHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
        gameOverScore.text = "Score: " + scoreManager.currentScore + "\nHigh Score: " + highScoreToDisplay;
        
    }

    void CheckIfNewHighScore()
    {
        if (scoreManager.currentScore <= gameMaster.highScore) //No new high score
        {
            highScoreToDisplay = gameMaster.highScore;
        }
        else
        {
            
            gameMaster.highScore = scoreManager.currentScore;
            gameMaster.Save();
            highScoreToDisplay = gameMaster.highScore;
            //New high score
        }
    }
}
