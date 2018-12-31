using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {


    private void Start()
    {
        //deathMenuCanvas.SetActive(false);
    
    }

    
    

    public void BeginGame()
    {
        //GameMaster.gameMaster.playerIsDead = false;
        GameMaster.gameMaster.Save();
        Application.LoadLevel("LoadingScene");
        //audioManager.PlaySound("Phase1and2Song");
    }

    public void Restart()
    {

        GameMaster.gameMaster.Save();
        
        //GameMaster.gameMaster.isPaused = false;
        //GameMaster.gameMaster.playerIsDead = false;
        Application.LoadLevel("LoadingScene");
        //GameMaster.gameMaster.inABossFight = false;
        //audioManager.PlaySound("Phase1and2Song");
        //TODO: Destroy the GameMaster.
    }

    public void ReturnToMainMenu()
    {
        GameMaster.gameMaster.Save();
        //GameMaster.gameMaster.playerIsDead = false;
        Time.timeScale = 1;
        Application.LoadLevel("MainMenu");
    }

    public void ReturnToMainMenuNoSave()
    {
        Time.timeScale = 1;
        Application.LoadLevel("MainMenu");
    }

    public void UpgradeScene()
    {
        GameMaster.gameMaster.Save();
        Application.LoadLevel("UpgradeSCene");
    }
    public void ExitGame()
    {
        GameMaster.gameMaster.Save();
        Application.Quit();
    }

    

}
