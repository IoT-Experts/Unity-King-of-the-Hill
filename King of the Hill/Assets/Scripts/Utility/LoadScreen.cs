using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {
	public GameObject LoadScreenObj;
	// Use this for initialization
	void Awake () 
	{
		Time.timeScale = 0;
		if(PlayerPrefs.GetInt("PlayLoadScreen") == 0)
		{
			Time.timeScale = 1;
			gameObject.SetActive(false);
		}
	}
	void Start ()
	{
		if(PlayerPrefs.GetInt("PlayLoadScreen") == 1)
		{
			PlayerPrefs.SetInt("PlayLoadScreen",0);
			LoadScreenObj.SetActive(true);
		}
	}
		
	public void GateOpen ()
	{
		Time.timeScale = 1.0f;
		PlayerPrefs.SetInt("PlayLoadScreen",0);
		gameObject.SetActive(false);

	}
}
