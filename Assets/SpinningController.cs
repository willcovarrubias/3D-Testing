using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningController : MonoBehaviour {

    public float speed;
    public GameObject difficultyManagerObject;
    DifficultyManager difficultyManagerScript;
	// Use this for initialization
	void Start () {
        difficultyManagerScript = difficultyManagerObject.GetComponent<DifficultyManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (difficultyManagerScript.gameIsTransitioning || !difficultyManagerScript.gameHasStarted || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3
            || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            
        }
        else
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);

        }
    }
}
