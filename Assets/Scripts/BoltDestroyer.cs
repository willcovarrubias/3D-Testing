using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDestroyer : MonoBehaviour {

    //public float timeToDestroyObject;
    public GameObject boltHead;

    AudioManager audioManager;
    // Use this for initialization
    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No audio manager found!");
        }

        MeshRenderer _meshRenderer = GetComponent<MeshRenderer>();
        MeshRenderer _meshRenderer2 = boltHead.GetComponent<MeshRenderer>();
       // StartCoroutine(DestroyedBlinkingEffect(_meshRenderer, _meshRenderer2, .1f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Destroy(gameObject, timeToDestroyObject);
    }

    IEnumerator DestroyedBlinkingEffect(MeshRenderer meshRenderer, MeshRenderer meshRenderer2, float blinkTime)
    {
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 5; i++)
        {
            meshRenderer.enabled = true;
            meshRenderer2.enabled = true;
            yield return new WaitForSeconds(blinkTime);
            meshRenderer.enabled = false;
            meshRenderer2.enabled = false;
            yield return new WaitForSeconds(blinkTime);
        }

        Destroy(gameObject);
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameMaster.gameMaster.boltsCollected++;
            audioManager.PlaySound("Pickup");
            Destroy(gameObject);
        }
    }
}
