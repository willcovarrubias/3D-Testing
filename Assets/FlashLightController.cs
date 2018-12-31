using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour {

    public GameObject difficultyManagerObject;
    DifficultyManager difficultyManagerScript;
    Animator anim;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        difficultyManagerScript = difficultyManagerObject.GetComponent<DifficultyManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //2 3 5 9
        if (difficultyManagerScript.gameIsTransitioning || !difficultyManagerScript.gameHasStarted || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3
            || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
        {
            anim.SetBool("Red", true);
        }
        else
        {
            anim.SetBool("Red", false);
        }
	}
}
