using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //private int moveSpeed;
    public float bulletDespawn;
    private Animator _animator;
    //private BoxCollider2D collider;

    public float thrust;
    private Rigidbody rigidBody;
    
    // Use this for initialization

    AudioManager audioManager;

    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        //collider = GetComponent<BoxCollider2D>();
        //moveSpeed = Random.Range(minTime, maxTime);
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("There's no audio manager!");
        }

        /*if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
            thrust = 345;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
            thrust = 340;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
            thrust = 335;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
            thrust = 330;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
            thrust = 325;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
            thrust = 320;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
            thrust = 315;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
            thrust = 310;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
            thrust = 305;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1)
            thrust = 300;*/

        rigidBody.AddForce(transform.forward * thrust, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletDespawn);
    }

    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        
        //_animator.Play("Rotate");
       // Destroy(gameObject, bulletDespawn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            audioManager.PlaySound("Hit");

    }


}
