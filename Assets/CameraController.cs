using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject difficultyManagerObject;

    DifficultyManager difficultyManagerScript;

    GameMaster gameMaster;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        difficultyManagerScript = difficultyManagerObject.GetComponent<DifficultyManager>();

        anim.Play("CameraStart");
	}
	
	// Update is called once per frame
	void Update () {

        if (difficultyManagerScript.gameIsTransitioning)
        {
            anim.SetBool("Transitioning", true);
        }
        else
        {
            anim.SetBool("Transitioning", false);

        }


        /*if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase2)
        {
            anim.SetBool("InBossFight", true);
        }
        else
        {
            anim.SetBool("InBossFight", false);
        }*/
    }
}
