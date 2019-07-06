using UnityEngine;
using System.Collections;

public class FirstMenuCanvas : MonoBehaviour {

	public GameObject SecondCanvas;
	public GameObject UpgradeMenu;
	public GameObject Shop_Object;
	public UpgradeMenuCanvas upgr_menu_scr;
	private GameObject me;
	public AudioClip ButtonSound; 
	public static bool after_death = false;
	void Start ()
	{
		me = gameObject;
		CheckAfterDeath();
	}
	public void CheckAfterDeath ()
	{
		if(after_death)
		{
			after_death = false;
			me.SetActive(false);
			UpgradeMenu.SetActive(true);
			int cur_hero = PlayerPrefs.GetInt("HeroChoosen");
			upgr_menu_scr.LoadStrings(cur_hero);
		}
	}
	public void Play()
	{
		MusicManager.instance.PlayMusic(ButtonSound);
		me.SetActive(false);
		SecondCanvas.SetActive(true);
	}
	public void Shop()
	{
		Shop_Canvas.back_canvas = 1;
		Shop_Object.SetActive(true);
		gameObject.SetActive(false);
	}

	public void Options()
	{
		Debug.Log("Options");

	}
	

}
