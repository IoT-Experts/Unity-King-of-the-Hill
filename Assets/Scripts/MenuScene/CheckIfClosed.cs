using UnityEngine;
using System.Collections;

public class CheckIfClosed : MonoBehaviour {
	public string name;
	public GameObject open;
	public GameObject closed;
	// Use this for initialization

	
	public void CheckClosed ()
	{
		if(PlayerPrefs.GetString(name) == "Open")
		{
			open.SetActive(true);
			closed.SetActive(false);
		} else
		{
			closed.SetActive(true);
			open.SetActive(false);
		}
	}

	void OnEnable ()
	{
		CheckClosed();
	}
}
