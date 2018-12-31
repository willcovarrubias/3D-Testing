using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

    public float speed;

    private int positionForBackground;

    private bool[] transitionSound = new bool[9];
    //private bool backgroundIsStationary;
    private bool[] playingConveyorSound = new bool[10];

    AudioManager audioManager;
    public GameObject difficultyManagerObject;
    DifficultyManager difficultyManager;

    // Use this for initialization
    void Start() {
        difficultyManager = difficultyManagerObject.GetComponent<DifficultyManager>();
        
        audioManager = AudioManager.instance;
        speed = 2;
        positionForBackground = 0;
    }

    // Update is called once per frame
    void Update() {

        

        positionForBackground = (int)GameMaster.gameMaster.chronologicalPhase * 14;


        Vector2 offset = new Vector2(Time.time * -speed, 0);
        //transform.Translate(offset, );
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-positionForBackground, transform.position.y, transform.position.z), step);

        


        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 && transitionSound[0] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[0] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3 && transitionSound[1] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[1] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4 && transitionSound[2] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[2] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 && transitionSound[3] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[3] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6 && transitionSound[4] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[4] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7 && transitionSound[5] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[5] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8 && transitionSound[6] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[6] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 && transitionSound[7] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[7] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10 && transitionSound[8] == false)
        {
            audioManager.StopSound("Conveyor");
            audioManager.PlaySound("Transition");
            transitionSound[8] = true;
        }

        PlayConveyorSound();
    }

    void PlayConveyorSound()
    {
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1 && !playingConveyorSound[0] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            Debug.Log("Phase 1 conveyor played.");
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[0] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 && !playingConveyorSound[1] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            Debug.Log("Phase 2 conveyor played.");
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[1] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3 && !playingConveyorSound[2] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[2] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4 && !playingConveyorSound[3] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[3] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 && !playingConveyorSound[4] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[4] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6 && !playingConveyorSound[5] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[5] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7 && !playingConveyorSound[6] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[6] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8 && !playingConveyorSound[7] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[7] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 && !playingConveyorSound[8] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[8] = true;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10 && !playingConveyorSound[9] && difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning)
        {
            audioManager.PlaySound("Conveyor");
            playingConveyorSound[9] = true;
        }
    }
}
