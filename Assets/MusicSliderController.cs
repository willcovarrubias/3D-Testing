using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderController : MonoBehaviour {

    GameMaster gameMaster;
    Slider slider;

	// Use this for initialization
	void Start () {

        slider = GetComponent<Slider>();
        gameMaster = GameMaster.gameMaster;
        slider.value = gameMaster.musicVolume;
	}
	
	// Update is called once per frame
	void Update () {
        gameMaster.musicVolume = slider.value;
	}
}
