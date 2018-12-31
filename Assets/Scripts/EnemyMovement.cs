using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    public float objectDespawn;
    public float thrust;

    private Rigidbody rigidBody;

    AudioManager audioManager;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.forward * thrust, ForceMode.Acceleration);
    }

    void Update()
    {
        Destroy(gameObject, objectDespawn);
    }
    


}
