using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll2 : MonoBehaviour {

    public float speed = .5f;
    public bool verticalItem;
    public GameObject difficultyManagerObject;
    private DifficultyManager difficultyManager;
    MeshRenderer renderer;
    //public Material[] materialToSet = new Material[10];
    bool[] transitionsStarted = new bool[10];

    Material[] currentMat;

    AudioManager audioManager;

    void Start()
    {
        difficultyManager = difficultyManagerObject.GetComponent<DifficultyManager>();

        renderer = GetComponent<MeshRenderer>();
        currentMat = GetComponent<MeshRenderer>().materials;

        //DetermineMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        if (difficultyManager.gameHasStarted == true && !difficultyManager.gameIsTransitioning)
        {
            if (verticalItem)
            {
                Vector2 offset = new Vector2(0, (Time.time * speed));
                Vector2 offset2 = new Vector2(-(Time.time * speed), 0.5f);
                renderer.materials[0].mainTextureOffset = offset;
                renderer.materials[1].mainTextureOffset = offset2;
            }
            else
            {
                Vector2 offset = new Vector2(-(Time.time * speed), 0);
                //renderer.material.mainTextureOffset = offset;
                renderer.materials[0].mainTextureOffset = offset;
                renderer.materials[1].mainTextureOffset = offset;
            }
            

        }
        //speed = ((float)GameMaster.gameMaster.currentPhase * .025f) + .15f;

        //10 = .25      11 = .275       12 = .3     13 = .325       14= .35

        //15 = .375     16 = .4     .425        .45     .475
        //20 = .5






    }
}
