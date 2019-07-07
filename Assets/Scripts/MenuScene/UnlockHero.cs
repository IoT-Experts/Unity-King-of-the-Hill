using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UnlockHero : MonoBehaviour {
	public string name;
	public Text price_text;
	public Button buy_button;
	public CheckIfClosed checker;
	public AudioClip Button_sound;
	public SecondMenuCanvas sec_menu_canvas;
	int price = 20000;
	int diamonds;
	// Use this for initialization
	void Start ()
	{
		price_text.text = price.ToString();
	}

	public void CheckIfCanBuy ()
	{
		if(diamonds >= price)
			buy_button.interactable = true;
		else 
			buy_button.interactable = false;
			
	}

	void OnEnable ()
	{
		diamonds = PlayerPrefs.GetInt("Diamonds");
		CheckIfCanBuy();
	}
	public void UnlockYourHero ()
	{
		if(PlayerPrefs.GetInt("Diamonds") >= price)
		{
			diamonds = PlayerPrefs.GetInt("Diamonds");
			diamonds -= price;
			PlayerPrefs.SetInt("Diamonds",diamonds);
			sec_menu_canvas.ChangeDiamonds();
			PlayerPrefs.SetString(name,"Open");
			MusicManager.instance.PlayMusic(Button_sound);
			checker.CheckClosed();
		}
	}
}
