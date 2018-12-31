using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackSound : MonoBehaviour {

    AudioSource audioSource;
    GameMaster gameMaster;
	// Use this for initialization
	void Start () {
        gameMaster = GameMaster.gameMaster;
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        audioSource.volume = gameMaster.soundVolume * audioSource.volume;
	}
}
