using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DifficultyManager : MonoBehaviour {

    public static DifficultyManager instance;
    float startTime;
    public float timeSurvived;
    public int phaseDuration;
    public float transitionDuration = 8;
    public float preTransDuration = 5;
    public int[] randomizedPhaseInt = new int[9];
    public List<int> listToChooseFrom = new List<int>();


    public bool gameHasStarted;
    public bool gameIsTransitioning;
    public bool gameIsPreTransition;

    PlatformController platformController;
    
	// Use this for initialization
	void Start () {


        gameHasStarted = false;
        gameIsTransitioning = false;
        
        //startTime = Time.deltaTime;
        GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1;
        GameMaster.gameMaster.acidCleanUps = 0;

        StartCoroutine(CountdownToBegin());
        GenerateListofInts();
        DeterminePhaseOrder();
	}
	
	// Update is called once per frame
	void Update () {

      

        if (gameHasStarted == true)
        {
            timeSurvived += Time.deltaTime;
        }
        

        if ((timeSurvived < phaseDuration )) //60
        {
            GameMaster.gameMaster.currentPhase = 0;
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase1;
        }
        if (timeSurvived > phaseDuration && timeSurvived < (phaseDuration * 2)) //65-120
        {
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[1];
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase2;
        }
        
        if ((timeSurvived > (phaseDuration * 2) ) && (timeSurvived < phaseDuration * 3)) //120-180
        {
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase3;
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[2];
        }

        if ((timeSurvived > ((phaseDuration * 3) )) && (timeSurvived < phaseDuration * 4)) //180-240
        {
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase4;
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[3];
        }
        
        if ((timeSurvived > ((phaseDuration * 4) )) && (timeSurvived < phaseDuration * 5)) //240-300
        {
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase5;
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[4];
        }

        if ((timeSurvived > ((phaseDuration * 5))) && (timeSurvived < phaseDuration * 6)) //300-360
        {
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase6;
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[5];
        }
      
        if ((timeSurvived > ((phaseDuration * 6) )) && (timeSurvived < phaseDuration * 7)) //360-420
        {
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase7;
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[6];
        }
      
        if ((timeSurvived > ((phaseDuration * 7) )) && (timeSurvived < phaseDuration * 8)) //420-480
        {
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase8;
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[7];
        }
     
        if (timeSurvived > ((phaseDuration * 8)) && timeSurvived < (phaseDuration * 9)) //480-540
        {
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase9;
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase1 + randomizedPhaseInt[8];
        }
     
        if (timeSurvived > (phaseDuration * 9)) //545-Infinite
        {
            GameMaster.gameMaster.currentPhase = GameMaster.CurrentPhase.Phase10;
            GameMaster.gameMaster.chronologicalPhase = GameMaster.ChronologicalPhase.cPhase10;

        }
        //GameMaster.gameMaster.currentDifficulty = GameMaster.CurrentDifficulty.Difficulty1;


        //These conditions are to make provide 10 seconds of transition per phase beginning.
        CheckForTransitionTimes();
        CheckForPreTransitionTimes();

        Debug.Log("Phase from GM: " + GameMaster.gameMaster.currentPhase.ToString());
    }

    private void DeterminePhaseOrder()
    {
        for (int i = 1; i < 9; i++)
        {
            System.Random ran = new System.Random();
            randomizedPhaseInt[i] = listToChooseFrom[ran.Next(listToChooseFrom.Count())];

            Debug.Log("Phase List:" + randomizedPhaseInt[i]);
            
            listToChooseFrom.Remove(randomizedPhaseInt[i]);
        }

        
    }

    private void GenerateListofInts()
    {
        
        for (int i = 1; i < 9; i++)
        {
            listToChooseFrom.Add(i);
        }


    }

    private void OnGUI()
    {
        //GUI.Label(new Rect(20, 10, 200, 800), "Time Survived: " + timeSurvived + "\nLevel " + ((int)GameMaster.gameMaster.currentDifficulty+1));
        //GUI.Label(new Rect(140, 10, 100, 40), "Ranged EXP: " + GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Ranged + 5]);
        //GUI.Label(new Rect(260, 10, 100, 40), "Character 03 unlocked: " + chars_Unlocked[2]);
    }

    IEnumerator CountdownToBegin()
    {
        yield return new WaitForSeconds(3);
        gameHasStarted = true;
    }

    void CheckForTransitionTimes()
    {
        if ((timeSurvived >= phaseDuration && timeSurvived < phaseDuration + transitionDuration)) //60
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 2) && timeSurvived < (2 * phaseDuration) + transitionDuration)) //65-120
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 3) && timeSurvived < (3 * phaseDuration) + transitionDuration)) //120-180
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 4) && timeSurvived < (4 * phaseDuration) + transitionDuration)) //180-240
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 5) && timeSurvived < (5 * phaseDuration) + transitionDuration)) //240-300
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 6) && timeSurvived < (6 * phaseDuration) + transitionDuration)) //300-360
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 7) && timeSurvived < (7 * phaseDuration) + transitionDuration)) //360-420
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 8) && timeSurvived < (8 * phaseDuration) + transitionDuration)) //420-480
        {
            gameIsTransitioning = true;
        }
        else if ((timeSurvived >= (phaseDuration * 9) && timeSurvived < (9 * phaseDuration) + transitionDuration)) //480-540
        {
            gameIsTransitioning = true;
        }
        /*else if ((timeSurvived >= (phaseDuration * 10) && timeSurvived < (10 * phaseDuration) + transitionDuration)) //545-Infinite
        {
            gameIsTransitioning = true;
        }*/
        else
        {
            gameIsTransitioning = false;
        }
    }

    void CheckForPreTransitionTimes()
    {
        float conveyorSpinTime = 12;

        if ((timeSurvived >= phaseDuration - conveyorSpinTime && timeSurvived < phaseDuration + transitionDuration)) //60
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 2) - conveyorSpinTime) && timeSurvived < (2 * phaseDuration) + transitionDuration)) //65-120
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 3) - conveyorSpinTime) && timeSurvived < (3 * phaseDuration) + transitionDuration)) //120-180
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 4) - conveyorSpinTime) && timeSurvived < (4 * phaseDuration) + transitionDuration)) //180-240
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 5) - conveyorSpinTime) && timeSurvived < (5 * phaseDuration) + transitionDuration)) //240-300
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 6) - conveyorSpinTime) && timeSurvived < (6 * phaseDuration) + transitionDuration)) //300-360
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 7) - conveyorSpinTime) && timeSurvived < (7 * phaseDuration) + transitionDuration)) //360-420
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 8) - conveyorSpinTime) && timeSurvived < (8 * phaseDuration) + transitionDuration)) //420-480
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 9) - conveyorSpinTime) && timeSurvived < (9 * phaseDuration) + transitionDuration)) //480-540
        {
            gameIsPreTransition = true;
        }
        else if ((timeSurvived >= ((phaseDuration * 10) - conveyorSpinTime) && timeSurvived < (10 * phaseDuration) + transitionDuration)) //545-Infinite
        {
            gameIsPreTransition = true;
        }
        else
        {
            gameIsPreTransition = false;
        }
    }
}
