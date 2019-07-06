using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	public GameObject Sound_ON;
	public GameObject Sound_OFF;
	string state = "ON";
	// Use this for initialization
	void Awake ()
	{
		if(PlayerPrefs.GetString("Sound_State") == "" )
			{
				PlayerPrefs.SetString("Sound_State","ON");
			}
	}
	void Start () 
	{
		state = PlayerPrefs.GetString("Sound_State");
		if(state == "OFF")
		{
			Sound_OFF.SetActive(true);
		} else 
		{
			Sound_ON.SetActive(true);
		}
	}
	public void Set_ON ()
	{
		PlayerPrefs.SetString("Sound_State","ON");
		MusicManager.instance.Change_StateON();
		Sound_ON.SetActive(true);
		Sound_OFF.SetActive(false);
	}
	public void Set_OFF ()
	{
		PlayerPrefs.SetString("Sound_State","OFF");
		MusicManager.instance.Change_StateOFF();
		Sound_ON.SetActive(false);
		Sound_OFF.SetActive(true);
	}
}
