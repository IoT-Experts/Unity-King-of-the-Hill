using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SecondMenuCanvas : MonoBehaviour {
	public GameObject[] HeroesChoose;
	public GameObject[] Icons;
	public GameObject[] ShadowIcons;
	public GameObject UpgradeMenuCanvas;
	public GameObject Shop_Object;
	public UpgradeMenuCanvas upgr_menu_scr;
	public GameObject me;
	public GameObject Price;
	public Text your_diam;
	int current_hero = 0;
	int heroes_count;
	public AudioClip Button_sound;
	public RectTransform cart;
	// Use this for initialization

	void Start ()
	{
		me = gameObject;
		HeroesChoose[current_hero].SetActive(true);
		Icons[current_hero].SetActive(true);
		ShadowIcons[current_hero].SetActive(false);
		heroes_count = HeroesChoose.Length;
		your_diam.text = PlayerPrefs.GetInt("Diamonds").ToString();
	}

	public void ChangeDiamonds()
	{
		your_diam.text = PlayerPrefs.GetInt("Diamonds").ToString();
	}

	void OnEnable ()
	{
		your_diam.text = PlayerPrefs.GetInt("Diamonds").ToString();

		MenuEventManager.swipe_left += Left;
		MenuEventManager.swipe_right += Right;
	}

	void OnDisable ()
	{
		MenuEventManager.swipe_left -= Left;
		MenuEventManager.swipe_right -= Right;
	}

	public void Right ()
	{
		MusicManager.instance.PlayMusic(Button_sound);
		if (current_hero != heroes_count - 1)
		{
			current_hero++;

			HeroesChoose[current_hero].SetActive(true);
			Icons[current_hero].SetActive(true);
			ShadowIcons[current_hero].SetActive(false);

			HeroesChoose[current_hero - 1].SetActive(false);
			Icons[current_hero - 1].SetActive(false);
			ShadowIcons[current_hero - 1].SetActive(true);
		} else
		{
		current_hero = 0;
			HeroesChoose[current_hero].SetActive(true);
			Icons[current_hero].SetActive(true);
			ShadowIcons[current_hero].SetActive(false);

			HeroesChoose[heroes_count - 1].SetActive(false);
			Icons[heroes_count - 1].SetActive(false);
			ShadowIcons[heroes_count - 1].SetActive(true);
		}
	}

	public void Left ()
	{
		MusicManager.instance.PlayMusic(Button_sound);
		if(current_hero != 0)
		{
			current_hero--;

			HeroesChoose[current_hero].SetActive(true);
			Icons[current_hero].SetActive(true);
			ShadowIcons[current_hero].SetActive(false);

			HeroesChoose[current_hero + 1].SetActive(false);
			Icons[current_hero + 1].SetActive(false);
			ShadowIcons[current_hero + 1].SetActive(true);
		} else
		{
			current_hero = heroes_count - 1;

			HeroesChoose[current_hero].SetActive(true);
			Icons[current_hero].SetActive(true);
			ShadowIcons[current_hero].SetActive(false);

			HeroesChoose[0].SetActive(false);
			Icons[0].SetActive(false);
			ShadowIcons[0].SetActive(true);
		}

	}

	public void IconChoose (int number)
	{
		MusicManager.instance.PlayMusic(Button_sound);

		HeroesChoose[current_hero].SetActive(false);
		Icons[current_hero].SetActive(false);
		ShadowIcons[current_hero].SetActive(true);

		HeroesChoose[number].SetActive(true);
		Icons[number].SetActive(true);
		ShadowIcons[number].SetActive(false);
		current_hero = number;
	}

	public void Choose()
	{
		MusicManager.instance.PlayMusic(Button_sound);
		me.SetActive(false);
		//Application.LoadLevel("GameScene");
		PlayerPrefs.SetInt("HeroChoosen",current_hero);
		UpgradeMenuCanvas.SetActive(true);
		upgr_menu_scr.LoadStrings(current_hero);
	}
	public void Shop ()
	{
		Shop_Canvas.back_canvas = 2;
		MusicManager.instance.PlayMusic(Button_sound);
		Shop_Object.SetActive(true);
		gameObject.SetActive(false);
	}
		
}
