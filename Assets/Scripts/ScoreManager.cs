using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {



    public static ScoreManager scoreManager;


    private int highScore;
    public int currentScore;

    private void Start()
    {
        highScore = GameMaster.gameMaster.highScore;
    }
}
