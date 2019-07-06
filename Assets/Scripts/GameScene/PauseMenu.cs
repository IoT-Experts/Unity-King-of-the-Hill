using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	public GameObject PausneMenu;
	public Shoot hero;
	public GameObject playerr;
	public AudioClip Button_Sound;
	public AudioSource Background_Music;
	// Use this for initialization

	void Start ()
	{
		playerr = GameObject.FindGameObjectWithTag("Player");
		hero = playerr.GetComponent<Shoot>();
	}

	public void clear ()
	{
		hero.clear();	
	}

	public void Pause ()
	{
		if(Time.timeScale != 0)
		{
		MusicManager.instance.PlayMusic(Button_Sound);
		MusicManager.instance.PauseExhaust();
		Time.timeScale = 0;
		PausneMenu.SetActive(true);
		Background_Music.Pause();
		EventManager.instance.isSwipe = false;
		}
	}

	public void Resume ()
	{
		Time.timeScale = 1;
		MusicManager.instance.PlayMusic(Button_Sound);
		MusicManager.instance.Resume_Exhaust();
		if(PlayerPrefs.GetString("PlayOnResume") == "Yes")
		{
			MusicManager.instance.CheckBackground();
			PlayerPrefs.SetString("PlayOnResume","No");
		}
		PausneMenu.SetActive(false);
		Background_Music.UnPause();
	}

	public void MainMenu ()
	{
		MusicManager.instance.PlayMusic(Button_Sound);
		Time.timeScale = 1;
		clear();
		SceneManager.LoadScene(0);
	}
	public void MainMenuDeath ()
	{
		MusicManager.instance.PlayMusic(Button_Sound);
		Time.timeScale = 1;
		clear();
		SceneManager.LoadScene(0);
		FirstMenuCanvas.after_death = true;
	}
	public void Restart ()
	{
		MusicManager.instance.PlayMusic(Button_Sound);
		Time.timeScale = 1;
		clear();
		SceneManager.LoadScene(1);
	}
}
