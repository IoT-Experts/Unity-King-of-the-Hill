using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DoublerChecker : MonoBehaviour {
	public Button doubler_button;
	// Use this for initialization
	void OnEnable ()
	{
		CheckDoubler();
	}
	public void CheckDoubler ()
	{
		if(PlayerPrefs.GetString("Doubler") == "Have")
			doubler_button.interactable = false;
	}

}
