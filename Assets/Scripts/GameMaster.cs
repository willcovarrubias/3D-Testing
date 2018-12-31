using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;



public class GameMaster : MonoBehaviour {

	public static GameMaster gameMaster;
	
    public int acidCleanUps;
	public int boltsCollected;

    [Range(0f, 1f)]
    public float soundVolume;
    [Range(0f, 1f)]
    public float musicVolume;

    public bool isPaused;
    //public bool playerIsDead;

    public bool[] unlockedPlatforms = new bool[26];
    public bool[] rowsWithPlatforms = new bool[6];

    public bool acidWasCleaned = false;
    public bool acidIconIsOn = false;


    //Character Stats
    public float[] characterSpeeds = new float[5];
    public float[] characterMass = new float[5];
    public float[] characterJumpHeight = new float[5];
    public float[] characterPunchCooldown = new float[5];

    public int highScore;

    //Unlocks
    public int[] numberOfUnlocks = new int[5] { 0,0,0,0,0};
            
    public enum CharacterChosen
    {
        Character1, Character2, Character3, Character4, Character5
    }
    public CharacterChosen characterChosen;


    //Character1
	public enum CurrentPhase
    {
        Phase0 = 0, Phase1 = 1, Phase2 = 2, Phase3 = 3, Phase4 = 4, Phase5 = 5, Phase6 = 6, Phase7 = 7, Phase8 = 8, Phase9 = 9, Phase10 = 10
    }
	public CurrentPhase currentPhase;

    public enum ChronologicalPhase
    {
        cPhase1, cPhase2, cPhase3, cPhase4, cPhase5, cPhase6, cPhase7, cPhase8, cPhase9, cPhase10
    }
    public ChronologicalPhase chronologicalPhase;

    public void Awake()
	{
        

		if (gameMaster == null) 
		{
			DontDestroyOnLoad (gameObject);
			gameMaster = this;
		} 
		else if (gameMaster != this) 
		{
			Destroy(gameObject);
		}        
	}
    
	void Start()
	{

       
        SetDefaultValues();
        

        Load();
        Debug.Log(0 + "'s mass: " + characterMass[0] + ". Speed: " + characterSpeeds[0] + ". Luck: " + characterJumpHeight[0] + ". Platforms: " + characterPunchCooldown[0] );
        Debug.Log(1 + "'s mass: " + characterMass[1] + ". Speed: " + characterSpeeds[1] + ". Luck: " + characterJumpHeight[1] + ". Platforms: " + characterPunchCooldown[1]);
        Debug.Log(2 + "'s mass: " + characterMass[2] + ". Speed: " + characterSpeeds[2] + ". Luck: " + characterJumpHeight[2] + ". Platforms: " + characterPunchCooldown[2]);
        Debug.Log(3 + "'s mass: " + characterMass[3] + ". Speed: " + characterSpeeds[3] + ". Luck: " + characterJumpHeight[3] + ". Platforms: " + characterPunchCooldown[3]);
        Debug.Log(4 + "'s mass: " + characterMass[4] + ". Speed: " + characterSpeeds[4] + ". Luck: " + characterJumpHeight[4] + ". Platforms: " + characterPunchCooldown[4]);

       
    }


    public void ReturnToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    private void SetDefaultValues()
    {
        for (int i = 0; i < 5; i++)
        {
            characterSpeeds[i] = 1.5f;
            characterMass[i] = 10f;
            characterJumpHeight[i] = 10;
            characterPunchCooldown[i] = 0;
            numberOfUnlocks[i] = 0;
            musicVolume = .5f;
        }
    }

    /*
	public static void SetSVehicleHealthBar(float vehicleHealth)
	{
		gameMaster.vehicleHPBar.transform.localScale = new Vector3(vehicleHealth, gameMaster.vehicleHPBar.transform.localScale.y, gameMaster.vehicleHPBar.transform.localScale.z);
		gameMaster.vehicleHPBar.transform.localScale = new Vector3(Mathf.Clamp(vehicleHealth,0f ,1f), gameMaster.vehicleHPBar.transform.localScale.y, gameMaster.vehicleHPBar.transform.localScale.z);
	}*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

     
    }

    private void OnGUI()
    {
        //GUI.Label(new Rect(20, 10, 100, 40), "Weapon EXP: " + GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Weapons]);
        //GUI.Label(new Rect(140, 10, 100, 40), "Ranged EXP: " + GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Ranged + 5]);
        //GUI.Label(new Rect(260, 10, 100, 40), "Character 03 unlocked: " + chars_Unlocked[2]);
    }

    public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
       
		UpdatedPlayerData data = new UpdatedPlayerData ();
        data.boltsCollectedSave = boltsCollected;
        data.characterSpeedsSaved = characterSpeeds;
        data.characterMassSaved = characterMass;
        data.characterJumpHeight = characterJumpHeight;
        data.characterPunchCooldown = characterPunchCooldown;
        data.highScoreSaved = highScore;
        data.numberOfUnlocksSaved = numberOfUnlocks;
        data.savedSoundVolume = soundVolume;
        data.savedMusicVolume = musicVolume;
        //data.chars_Unlocked = chars_Unlocked;
        //data.allArmorExp = allArmorExp;

        bf.Serialize (file, data);
		file.Close ();
		Debug.Log ("Saving to: " + Application.persistentDataPath + "/playerInfo.dat");
	}
	
	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			UpdatedPlayerData data = (UpdatedPlayerData)bf.Deserialize(file);

            file.Close();

            boltsCollected = data.boltsCollectedSave;
            characterSpeeds = data.characterSpeedsSaved;
            characterMass = data.characterMassSaved;
            characterJumpHeight = data.characterJumpHeight;
            characterPunchCooldown = data.characterPunchCooldown;
            highScore = data.highScoreSaved;
            numberOfUnlocks = data.numberOfUnlocksSaved;
            soundVolume = data.savedSoundVolume;
            musicVolume = data.savedMusicVolume;
            //chars_Unlocked = data.chars_Unlocked;
            //allArmorExp = data.allArmorExp;
            
            Debug.Log ("Stats loaded!");
            
            

        }
	}
}

[Serializable]
class UpdatedPlayerData
{
    public float savedMusicVolume;
    public float savedSoundVolume;

    //Character Stats
    public float[] characterMassSaved = new float[5];
    public float[] characterSpeedsSaved = new float[5];
    public float[] characterJumpHeight = new float[5];
    public float[] characterPunchCooldown = new float[5];

    public int highScoreSaved;
    public int[] numberOfUnlocksSaved = new int[5];

    public int boltsCollectedSave;
    public bool[] chars_Unlocked = new bool[21];
    public int[] allArmorExp = new int[70];

    public bool char01HPUnlock01 = false;

    private int base01Life;
    private int base01Mana;
    private int base01Att;
    private int base01SpAtt;
    private int base01Def;
    private int base01Speed;

  
}


