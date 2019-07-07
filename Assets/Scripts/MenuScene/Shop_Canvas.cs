using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Shop_Canvas : MonoBehaviour {

	public static int back_canvas;
	public GameObject First_Canvas,Second_Canvas,Third_Canvas;
	public UpgradeMenuCanvas upg_scr;
	public Text diam_text;
	public AudioClip back_sound;

	// Use this for initialization
	void Start () 
	{
		if(back_canvas == 0)
			back_canvas = 1;
		ChangeDiamText();
	}
	
	public void Back ()
	{
		switch(back_canvas)
		{
		case 1:
			First_Canvas.SetActive(true);
			gameObject.SetActive(false);
			MusicManager.instance.PlayMusic(back_sound);
			break;
		case 2:
			Second_Canvas.SetActive(true);
			gameObject.SetActive(false);
			MusicManager.instance.PlayMusic(back_sound);
			break;
		case 3:
			upg_scr.LoadStrings(PlayerPrefs.GetInt("HeroChoosen"));
			Third_Canvas.SetActive(true);
			gameObject.SetActive(false);
			MusicManager.instance.PlayMusic(back_sound);
			break;
		}
	}
	public void ChangeDiamText ()
	{
		int dia = PlayerPrefs.GetInt("Diamonds");
		diam_text.text = dia.ToString();
	}

}
