using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Sound
{

	public string name;
	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = 0.7f;
	[Range(0.5f, 1.5f)]
	public float pitch = 1f;

	[Range(0f, 0.5f)]
	public float randomVolume = 0.1f;
	[Range(0f, 0.5f)]
	public float randomPitch = 0.1f;

	public bool loop = false;

	private AudioSource source;

	public void SetSource(AudioSource _source)
	{
		source = _source;
		source.clip = clip;
		source.loop = loop;
	}

	public void Play(float mainVolume)
	{
		source.volume = mainVolume * volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
		source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
		source.Play();
	}

    public IEnumerator FadeIn(float mainVolume)
    {
        //source.pitch = 1;
        source.Play();
        source.volume = 0 * mainVolume;
        yield return new WaitForSeconds(1);
        source.volume = .2f * mainVolume;
        yield return new WaitForSeconds(1);
        source.volume = .4f * mainVolume;
        yield return new WaitForSeconds(1);
        source.volume = .6f * mainVolume;
        yield return new WaitForSeconds(1);
        source.volume = mainVolume;



    }

    public IEnumerator FadeOut(float mainVolume)
    {
 
        source.volume = .4f * mainVolume;
        yield return new WaitForSeconds(1);
        source.volume = .2f * mainVolume;
        yield return new WaitForSeconds(1);
        source.volume = 0 * mainVolume;
        yield return new WaitForSeconds(1);
        source.Stop();
    }

    public void Stop()
	{
		source.Stop();
	}

    public void SetVolume(float mainVolume)
    {
        source.volume = mainVolume;
    }

}

public class AudioManager : MonoBehaviour
{
    GameMaster gameMaster;
    
	public static AudioManager instance;
    [Range(0f, 1f)]
    public float mainSoundVolume;
    [Range(0f, 1f)]
    public float mainMusicVolume;

    Slider musicSlider;

	[SerializeField]
	Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			if (instance != this)
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}

        //mainVolume = whatever main volume from GM is.
	}

	void Start()
	{
        
        gameMaster = GameMaster.gameMaster;

		for (int i = 0; i < sounds.Length; i++)
		{
			GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
			_go.transform.SetParent(this.transform);
			sounds[i].SetSource(_go.AddComponent<AudioSource>());
		}

		//PlaySound("Music");
	}

	public void PlaySound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Play(gameMaster.soundVolume);
				return;
			}
		}

		// no sound with _name
		Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
	}

	public void StopSound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Stop();
				return;
			}
		}

		// no sound with _name
		Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
	}

    public void FadeInSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                StartCoroutine( sounds[i].FadeIn(gameMaster.musicVolume));
                return;
            }
        }

        // no sound with _name
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }

    public void FadeOutSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                StartCoroutine(sounds[i].FadeOut(gameMaster.musicVolume));
                return;
            }
        }

        // no sound with _name
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }

    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (gameMaster.isPaused)
            {
                sounds[i].SetVolume(gameMaster.musicVolume);

            }
            
        }

        //Sets conveyor belt volume in real time.
        sounds[8].SetVolume(gameMaster.soundVolume);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DeathScene") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LoadingScene"))
        {
            StopSound("Conveyor");
        }
    }

    public void SetMusicVolume(float input)
    {
        mainMusicVolume = input;
    }
}
