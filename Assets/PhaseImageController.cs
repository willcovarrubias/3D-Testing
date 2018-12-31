using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseImageController : MonoBehaviour {

    public GameObject difficultyManagerObject;
    public Transform imageTransformLocation;
    DifficultyManager difficultyManagerScript;

    public int imageID;
    SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        difficultyManagerScript = difficultyManagerObject.GetComponent<DifficultyManager>();



        if (difficultyManagerScript == null)
        {
            Debug.Log("THe one causing the issue is: " + imageID);
        }
        //spriteRender.sprite = Resources.Load("Misc/TransitionImage" + difficultyManagerScript.listToChooseFrom), new Vector3(imageTransformLocation.position.x, imageTransformLocation.position.y, imageTransformLocation.position.z), Quaternion.Euler(0 , 0, 0));
        // + difficultyManagerScript.listToChooseFrom);

        DetermineWhatImageToLoad(imageID);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DetermineWhatImageToLoad(int id)
    {

        //spriteRenderer.sprite = Resources.Load<Sprite>("Misc/TransitionImage" + difficultyManagerScript.randomizedPhaseInt[id]);
        GameObject background = Instantiate(Resources.Load("Background/Phase" + (difficultyManagerScript.randomizedPhaseInt[id] + 1) ), new Vector3(imageTransformLocation.position.x, imageTransformLocation.position.y, imageTransformLocation.position.z), Quaternion.Euler(0 , 0, 0)) as GameObject;
       //GameObject background = Instantiate(Resources.Load("Background/Phase3"), new Vector3(imageTransformLocation.position.x, imageTransformLocation.position.y, imageTransformLocation.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;

        background.transform.parent = this.transform;
        

    }
}
