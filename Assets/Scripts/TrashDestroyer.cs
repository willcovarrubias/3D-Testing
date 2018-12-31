using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDestroyer : MonoBehaviour {

    AudioManager audioManager;
    

    Rigidbody rb;
    public float boomForce;
	// Use this for initialization
	void Start () {
        audioManager = AudioManager.instance;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -15)
            Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")
        {
            audioManager.PlaySound("Hit");
            //rb.AddForce(transform.forward * boomForce, ForceMode.Impulse);
            //rb.AddExplosionForce(1000, other.transform.position, 2);
            if (other.transform.position.z < this.transform.position.z)
            {
                if (other.transform.position.x < this.transform.position.x) //Object is to the right of the player
                {
                    //rb.AddForce((new Vector3(other.transform.position.x * boomForce, (other.transform.position.y * boomForce), (other.transform.position.z * boomForce))), ForceMode.Impulse);
                    //rb.AddRelativeForce((new Vector3(boomForce, boomForce, boomForce)), ForceMode.Impulse);
                    rb.AddForce(new Vector3(boomForce, boomForce, -boomForce), ForceMode.Impulse);

                }
                else
                {
                    //rb.AddForce((new Vector3(-other.transform.position.x * boomForce, (other.transform.position.y * boomForce), (other.transform.position.z * boomForce))), ForceMode.Impulse);
                    //rb.AddRelativeForce((new Vector3(-boomForce, boomForce, boomForce)), ForceMode.Impulse);
                    rb.AddForce(new Vector3(-boomForce, boomForce, -boomForce), ForceMode.Impulse);
                }
            }
            else
            {
                if (other.transform.position.x < this.transform.position.x) //Object is to the right of the player
                {
                    //rb.AddForce((new Vector3(other.transform.position.x * boomForce, (other.transform.position.y * boomForce), (-other.transform.position.z * boomForce))), ForceMode.Impulse);
                   //rb.AddForce((new Vector3(boomForce * 2, boomForce, -boomForce)), ForceMode.Impulse);
                    rb.AddForce(new Vector3(boomForce, boomForce, boomForce), ForceMode.Impulse);

                }
                else
                {
                   //rb.AddForce((new Vector3(-other.transform.position.x * boomForce, (other.transform.position.y * boomForce), (-other.transform.position.z * boomForce))), ForceMode.Impulse);
                    rb.AddForce(new Vector3(-boomForce, boomForce, boomForce), ForceMode.Impulse);
                }
            }
            
        }
    }
}
