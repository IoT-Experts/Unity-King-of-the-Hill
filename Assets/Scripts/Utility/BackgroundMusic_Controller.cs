using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BackgroundMusic_Controller : MonoBehaviour {
	public AudioClip MenuScene_Music;
	public AudioClip GamePlay_Music;
	public AudioSource me;
	// Use this for initialization
	void Start () 
	{
		if(Application.loadedLevel == 0)
		{
			me.clip = MenuScene_Music;
		} else
		{
			me.clip = GamePlay_Music;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Application.loadedLevel == 0)
		{
			me.clip = MenuScene_Music;
		} else
		{
			me.clip = GamePlay_Music;
		}
	}
}
