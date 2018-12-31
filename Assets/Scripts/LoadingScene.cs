using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {

    Text loadingText;
    private float timer;

    AudioManager audioManager;
    // Use this for initialization
    void Start () {
        loadingText = GetComponent<Text>();
        StartCoroutine(SceneLoader());
        timer = 0;

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No audio manager found!");
        }


        audioManager.FadeOutSound("MenuSong");

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 3)
            Application.LoadLevel("MainSceneTest");

    }

    IEnumerator SceneLoader()
    {
        loadingText.text = "Loading.";
        yield return new WaitForSeconds(1);
        loadingText.text = "Loading..";
        yield return new WaitForSeconds(1);
        loadingText.text = "Loading...";
        yield return new WaitForSeconds(1);
        Application.LoadLevel("MainScene");
        
    }
}
