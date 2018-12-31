using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour {

    MeshRenderer _renderer;
    public Material[] materialToSet = new Material[10];
    bool[] transitionsStarted = new bool[10];

    Material currentMat;

    AudioManager audioManager;

	void Start () {
        _renderer = GetComponent<MeshRenderer>();
        currentMat = GetComponent <MeshRenderer>().material;
        
        DetermineMaterial();
    }
	
	// Update is called once per frame
	void Update () {


    }

    void ChangeMaterial(int indexOfMaterial)
    {
        transitionsStarted[indexOfMaterial] = true;
        //yield return new WaitForSeconds(5);
        currentMat = materialToSet[indexOfMaterial];
        GetComponent<Renderer>().material = currentMat;
        
    }



    void DetermineMaterial()
    {
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
        {
            ChangeMaterial(0);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {

            ChangeMaterial(1);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
        {
            ChangeMaterial(2);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
        {
            ChangeMaterial(3);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
        {
            ChangeMaterial(4);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
        {
            ChangeMaterial(5);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
        {
            ChangeMaterial(6);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            ChangeMaterial(7);
        }

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            ChangeMaterial(8);
        }
    }

}
