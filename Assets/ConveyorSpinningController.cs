using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSpinningController : MonoBehaviour {

    public GameObject difficultyManagerObject;
    DifficultyManager difficultyManagerScript;

    Animator anim;
    // Use this for initialization
    void Start()
    {
        difficultyManagerScript = difficultyManagerObject.GetComponent<DifficultyManager>();
        anim = GetComponent<Animator>();
        anim.Play("ConveyorTooth");
    }

    // Update is called once per frame
    void Update () {



        if (difficultyManagerScript.gameIsTransitioning || !difficultyManagerScript.gameHasStarted || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3
            || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
            {
            
            anim.enabled = false;
        }
        else
        {
            //anim.SetBool("Spinning", true);
            anim.enabled = true;
        }

        
	}
}
