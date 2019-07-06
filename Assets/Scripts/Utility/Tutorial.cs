using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	public GameObject tut;
	public AudioClip button_sound;
	// Use this for initialization
	void Start ()
	{
		if((PlayerPrefs.GetString("Tutorial") == ""))
		{
			StartCoroutine("ShowTutorial");
		} 
		else
		{
			Resources.UnloadUnusedAssets();
		}
	}

	IEnumerator ShowTutorial ()
	{
		yield return new WaitForSeconds(0.5f);
		Time.timeScale = 0;
		PlayerPrefs.SetString("Tutorial","was_showed");
		tut.SetActive(true);
	}

	public void CloseTutorial ()
	{
		Time.timeScale = 1.0f;
		PlayerPrefs.SetString("Tutorial","was_showed");
		tut.SetActive(false);
		MusicManager.instance.PlayMusic(button_sound);
		Resources.UnloadUnusedAssets();
	}
}
