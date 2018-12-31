using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public static PauseMenu pauseMenu; 
	//public static bool isPaused;

	public GameObject pauseMenuCanvas;
	//public GameObject eventSystem;


    //Controller2D controller2D;
    PlayerExample player;
    //GameMaster gm;
    //GameObject gameMaster;

    private void Awake()
    {
        
    }

    void Start()
	{
        Time.timeScale = 1;
        //gm = new GameMaster();
        pauseMenuCanvas.SetActive(false);
        GameMaster.gameMaster.isPaused = false;

        //controller2D = GetComponent<Controller2D> ();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExample>();
        //gameMaster = GameObject.FindGameObjectWithTag("GameMaster");


    }
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetButtonDown("Pause"))
        {
            
                GameMaster.gameMaster.isPaused = !GameMaster.gameMaster.isPaused;

                if (GameMaster.gameMaster.isPaused)
                {
                    Time.timeScale = 0;
                    pauseMenuCanvas.SetActive(true);
                }
                else if (!GameMaster.gameMaster.isPaused)
                {
                    Time.timeScale = 1;
                    pauseMenuCanvas.SetActive(false);
                    GameMaster.gameMaster.Save();
                }
            
        }

        /*if(GameMaster.gameMaster.isPaused == false)
		{
            pauseMenuCanvas.SetActive(false);
            //eventSystem.gameObject.SetActive(false);
            Time.timeScale = 1f;
            //player.GetComponent<Player>().enabled = false;
            //player.gameObject.SetActive(false);
            //controller2D.enabled = false;
            Debug.Log(GameMaster.gameMaster.isPaused);

        }
        /*else if(GameMaster.gameMaster.isPaused == false && BossInstantiater.currentlyPlayingBossIntro == false)
		{

        
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;

			//player.gameObject.SetActive(true);
			//controller2D.enabled = true;
			//player.GetComponent<Player>().enabled = true;
			}

        if (GameMaster.gameMaster.isPaused)
        {
            eventSystem.gameObject.SetActive(true);
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log(GameMaster.gameMaster.isPaused);
            if (Input.GetButtonDown("Pause"))
            {
                GameMaster.gameMaster.isPaused = false;
            }
        }


        if (Input.GetButtonDown("Pause"))
        {
            GameMaster.gameMaster.isPaused = true;
            Debug.Log(GameMaster.gameMaster.isPaused);
        }*/
    }


    
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuCanvas.SetActive(true);
        GameMaster.gameMaster.isPaused = true;
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        GameMaster.gameMaster.Save();
        Time.timeScale = 1;
        pauseMenuCanvas.SetActive(false);
        //enable the scripts again
    }

    public void Resume()
	{
        
        ContinueGame();
		GameMaster.gameMaster.isPaused = false;
	}

	public void Restart()
	{
        ContinueGame();
		Application.LoadLevel("LoadingScene");
		GameMaster.gameMaster.isPaused = false;
        //GameMaster.gameMaster.inABossFight = false;

		//TODO: Destroy the GameMaster.
	}
	
	public void ExitGame()
	{
		Application.Quit();
	}

}
