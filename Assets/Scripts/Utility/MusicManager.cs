using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public static MusicManager instance;
	public AudioSource curr_audio;
	string state;
	GameObject MusicBackground;
	public AudioSource Background;
	public AudioSource Exhaust_Player;
	public bool lose = false;
	//public AudioSource RangeEnemy_Player;
	// Use this for initialization
	void Start ()
	{
		lose = false;
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		state = PlayerPrefs.GetString("Sound_State");
		AssignBackground();
	}
	public void AssignBackground ()
	{
		MusicBackground = GameObject.Find("Music_Background");
		Background = MusicBackground.GetComponent<AudioSource>();
		CheckBackground();
	}
	public void CheckBackground ()
	{
		if(Background == null)
		{
			AssignBackground();
		}
		if(state == "ON")
		{
			if(Time.timeScale == 0)
			{
				//Background.Play();
				PlayerPrefs.SetString("PlayOnResume","Yes");
			} else
			{
				Background.Play();
			}
		}
		else
		{
			Background.Stop();
		}
	}
	
	public void PlayMusic(AudioClip music)
	{
		if((state == "ON") && (!lose))
		{
		curr_audio.clip = music;
		curr_audio.Play();		
		Debug.Log("Played");
		}
	}
	public void PlayExhaust(AudioClip music)
	{
		if((state == "ON") && (!lose))
		{
			Exhaust_Player.clip = music;
			Exhaust_Player.Play();
		}
	}
	public void PauseExhaust()
	{
		Exhaust_Player.Pause();
	}
	public void Change_StateON ()
	{
		state = "ON";
		CheckBackground();
	}
	public void Change_StateOFF ()
	{
		state = "OFF";
		CheckBackground();
	}
	public void Resume_Exhaust ()
	{
		if(state == "ON")
		{
			Exhaust_Player.UnPause();
		}
	}

	public void Stop_Exhaust ()
	{
		Exhaust_Player.clip = null;
		Exhaust_Player.Stop();
	}

}
