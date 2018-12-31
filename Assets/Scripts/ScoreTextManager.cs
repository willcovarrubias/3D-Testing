using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManager : MonoBehaviour {


    //public static ScoreManager scoreManager;
    //private int pointsForSuccessfulClean;
    public Text scoreText;
    public Text highScoreText;
    public Text level;

    public GameObject gameMasterObject;
    private DifficultyManager difficultyManager;

    float timeSurvived;
    int currentScore;
    ScoreManager scoreManager;
    GameMaster gameMaster;


    // Use this for initialization
    void Start()
    {
        //scoreText = GetComponent<Text>();
        difficultyManager = gameMasterObject.GetComponent<DifficultyManager>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        scoreManager = gameMaster.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //float timeSurvived;
        timeSurvived += Time.deltaTime;
        currentScore = (int)difficultyManager.timeSurvived + gameMaster.acidCleanUps;
        scoreText.text = "Score: " + "\n" + currentScore + "\n" + "\nBolts: " + "\n" + gameMaster.boltsCollected;
        highScoreText.text = "High Score: " + gameMaster.highScore;
        scoreManager.currentScore = currentScore;


        level.text = "Level: " + gameMaster.currentPhase + "\nChronoPhase: " + gameMaster.chronologicalPhase;
    }
}
