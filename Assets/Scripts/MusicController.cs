using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {

    AudioManager audioManager;
    GameMaster gameMaster;
    Scene currentScene;
    string sceneName;

    bool playingMainMenuSong;
    bool playingFirstSong;
    bool playingSecondSong;
    bool playingThirdSong;
    bool playingFourthSong;
    bool playingFifthSong;
    bool playingDeathSong;

    private void Start()
    {
      
        audioManager = AudioManager.instance;
        gameMaster = GameMaster.gameMaster;
    }

    private void Update()
    {


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (playingMainMenuSong == false)
            {
                StopAllSongs();
                audioManager.FadeInSound("MenuSong");
                playingMainMenuSong = true;
                playingDeathSong = false;

            }

        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainSceneTest"))
        {
            if (gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1 || gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
            {
                if (playingFirstSong == false)
                {
                    //Play first song;
                    StopAllSongs();
                    audioManager.FadeInSound("Phase1and2Song");
                    playingFirstSong = true;

                }
                playingMainMenuSong = false;
                playingSecondSong = false;
                playingThirdSong = false;
                playingFourthSong = false;
                playingFifthSong = false;
                playingDeathSong = false;
            }

            if (gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3 || gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
            {
                if (playingSecondSong == false)
                {
                    //Play second song;
                    audioManager.FadeOutSound("Phase1and2Song");
                    audioManager.FadeInSound("Phase3and4Song");
                    playingSecondSong = true;

                }

                playingMainMenuSong = false;
                playingFirstSong = false;
                playingThirdSong = false;
                playingFourthSong = false;
                playingFifthSong = false;

            }

            if (gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 || gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
            {
                if (playingThirdSong == false)
                {
                    audioManager.FadeOutSound("Phase3and4Song");
                    audioManager.FadeInSound("Phase5and6Song");
                    playingThirdSong = true;

                }

                playingMainMenuSong = false;
                playingFirstSong = false;
                playingSecondSong = false;
                playingFourthSong = false;
                playingFifthSong = false;

            }

            if (gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7 || gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
            {
                if (playingFourthSong == false)
                {
                    //Play second song;
                    audioManager.FadeOutSound("Phase5and6Song");
                    audioManager.FadeInSound("Phase7and8Song");
                    playingFourthSong = true;

                }

                playingMainMenuSong = false;
                playingFirstSong = false;
                playingSecondSong = false;
                playingThirdSong = false;
                playingFifthSong = false;

            }

            if (gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 || gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
            {
                if (playingFifthSong == false)
                {
                    //Play second song;
                    audioManager.FadeOutSound("Phase7and8Song");
                    audioManager.FadeInSound("Phase9and10Song");
                    playingFifthSong = true;

                }

                playingMainMenuSong = false;
                playingFirstSong = false;
                playingSecondSong = false;
                playingThirdSong = false;
                playingFourthSong = false;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DeathScene"))
        {
            if (playingDeathSong == false)
            {
                StopAllSongs();
                audioManager.FadeInSound("DeathSong");
                playingDeathSong = true;
                
            }

            playingMainMenuSong = false;
            playingFirstSong = false;
            playingSecondSong = false;
            playingThirdSong = false;
            playingFourthSong = false;
            playingFifthSong = false;
        }
    }

    void StopAllSongs()
    {

        audioManager.StopSound("Phase1and2Song");
        audioManager.StopSound("Phase3and4Song");
        audioManager.StopSound("Phase5and6Song");
        audioManager.StopSound("Phase7and8Song");
        audioManager.StopSound("Phase9and10Song");
        audioManager.StopSound("MenuSong");
        audioManager.StopSound("DeathSong");
    }

    void FadeOutPreviousSong()
    {
        audioManager.FadeOutSound("Phase1and2Song");
        audioManager.FadeOutSound("Phase3and4Song");
        audioManager.FadeOutSound("Phase5and6Song");
        audioManager.FadeOutSound("Phase7and8Song");
        audioManager.FadeOutSound("Phase9and10Song");
        audioManager.FadeOutSound("MenuSong");
        audioManager.FadeOutSound("DeathSong");
    }

}
