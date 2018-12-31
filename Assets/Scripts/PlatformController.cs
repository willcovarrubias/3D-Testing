using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public float moveSpeed;
    private int speedRandomizer;
    private Animator _animator;
    private BoxCollider2D collider;
    private Rigidbody2D rigidBody;
    private DifficultyManager difficultyManager;
    
   
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        moveSpeed = 3f;
      
        difficultyManager = GetComponent<DifficultyManager>();
     
	}
	
	// Update is called once per frame
	void Update () {


        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
            moveSpeed = 3;            
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 )
            moveSpeed = 0;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8 )
            moveSpeed = 3;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7 )
            moveSpeed = 3;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6 )
            moveSpeed = 3;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
            moveSpeed = 0;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4 )
            moveSpeed = 3;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3 )
            moveSpeed = 0;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
            moveSpeed = 0;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1 )
            moveSpeed = 3;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase0)
            moveSpeed = 3;

    }

	void FixedUpdate () {

        if(difficultyManager.gameHasStarted == true && !difficultyManager.gameIsTransitioning)
		transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
 
	}

   


}
