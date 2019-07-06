using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UpgradeMenuCanvas : MonoBehaviour {
	public GameObject second_menu_canvas;
	public GameObject Shop_Object;
	public Text your_diamonds;
	int Diamonds;

	public AudioClip Buy_Button;
	public AudioClip Arrow_Button;

	public GameObject load_screen;
	//public int upgrade_data;
	//public GameObject square_castle;
	public Text[] Price_Texts;
	public Button[] BuyButtons;
	public GameObject[] Icons;
	public GameObject[] Weapon_Icons;
	public GameObject[] GoldSquaresPower; 
	public GameObject[] GoldSquaresStamina; 
	public GameObject[] GoldSquaresStamRegen; 
	public GameObject[] GoldSquaresCastle; 
	public GameObject[] GoldSquaresCritPower; 
	public GameObject[] GoldSquaresCritChance; 
	public GameObject[] GoldSquaresWeapon;
	int[] datas;
	private int hero_choosen;
	string power_str,stam_str,stam_regen_str,castle_str,crit_chance_str,crit_power_str,weapon_str;
	int power,stam,stam_regen,castle,crit_chance,crit_power,weapon;
	// Use this for initialization
	void Awake () 
	{
		hero_choosen = PlayerPrefs.GetInt("HeroChoosen");
		Diamonds = PlayerPrefs.GetInt("Diamonds");
		your_diamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
		LoadPrices();
		//datas = new int[7];

	}
	public void LoadStrings (int hero)
	{
	switch(hero)
		{
		case 0 :
			power_str = "olaf_power";
			stam_str = "olaf_stam";
			stam_regen_str = "olaf_stam_regen";
			castle_str = "olaf_castle";
			crit_chance_str ="olaf_crit_chance";
			crit_power_str = "olaf_crit_power";
			weapon_str = "olaf_weapon";
			break;
		case 1 : weapon_str = "olaf_weapon";
			power_str = "odi_power";
			stam_str = "odi_stam";
			stam_regen_str = "odi_stam_regen";
			castle_str = "odi_castle";
			crit_chance_str ="odi_crit_chance";
			crit_power_str = "odi_crit_power";
			weapon_str = "odi_weapon";
			break;
		case 2 :
			power_str = "fiona_power";
			stam_str = "fiona_stam";
			stam_regen_str = "fiona_stam_regen";
			castle_str = "fiona_castle";
			crit_chance_str ="fiona_crit_chance";
			crit_power_str = "fiona_crit_power";
			weapon_str = "fiona_weapon";
			break;
		case 3 :
			power_str = "morgana_power";
			stam_str = "morgana_stam";
			stam_regen_str = "morgana_stam_regen";
			castle_str = "morgana_castle";
			crit_chance_str ="morgana_crit_chance";
			crit_power_str = "morgana_crit_power";
			weapon_str = "morgana_weapon";
			break;
		case 4 :
			power_str = "maximus_power";
			stam_str = "maximus_stam";
			stam_regen_str = "maximus_stam_regen";
			castle_str = "maximus_castle";
			crit_chance_str ="maximus_crit_chance";
			crit_power_str = "maximus_crit_power";
			weapon_str = "maximus_weapon";
			break;
		case 5 :
			power_str = "boom-boom_power";
			stam_str = "boom-boom_stam";
			stam_regen_str = "boom-boom_regen";
			castle_str = "boom-boom_castle";
			crit_chance_str ="boom-boom_crit_chance";
			crit_power_str = "boom-boom_crit_power";
			weapon_str = "boom-boom_weapon";
			break;
		}
		LoadData();
		LoadPrices();
		LoadIcons(hero);
		SaveStrings();
	}

	public void LoadIcons (int hero)
	{
		for (int i=0; i<6; i++)
		{
			Icons[i].SetActive(false);
			Weapon_Icons[i].SetActive(false);
		}
		Weapon_Icons[hero].SetActive(true);
		Icons[hero].SetActive(true);
	}
	public void LoadData ()
	{
		power = PlayerPrefs.GetInt(power_str);
		LoadSquares(GoldSquaresPower,power);
		stam = PlayerPrefs.GetInt(stam_str);
		LoadSquares(GoldSquaresStamina,stam);
		stam_regen = PlayerPrefs.GetInt(stam_regen_str);
		LoadSquares(GoldSquaresStamRegen,stam_regen);
		castle = PlayerPrefs.GetInt(castle_str);
		LoadSquares(GoldSquaresCastle,castle);
		crit_power = PlayerPrefs.GetInt(crit_power_str);
		LoadSquares(GoldSquaresCritPower,crit_power);
		crit_chance = PlayerPrefs.GetInt(crit_chance_str);
		LoadSquares(GoldSquaresCritChance,crit_chance);
		weapon = PlayerPrefs.GetInt(weapon_str);
		LoadSquares(GoldSquaresWeapon,weapon);
		datas = new int[]{power,stam,stam_regen,castle,crit_power,crit_chance,weapon};
		datas[0] = power;
		datas[1] = stam;
		datas[2] = stam_regen;
		datas[3] = castle;
		datas[4] = crit_power;
		datas[5] = crit_chance;
		datas[6] = weapon;

		Diamonds = PlayerPrefs.GetInt("Diamonds");
		your_diamonds.text = Diamonds.ToString();
	}

	public void LoadPrices()
	{
		Price_Texts[0].text = Price_text(power);
		Price_Texts[1].text = Price_text(stam);
		Price_Texts[2].text = Price_text(stam_regen);
		Price_Texts[3].text = Price_text(castle);
		Price_Texts[4].text = Price_text(crit_power);
		Price_Texts[5].text = Price_text(crit_chance);
		Price_Texts[6].text = Price_text_weapon(weapon);
		for(int i=0;i < 6;i++)
		{
			if(Diamonds < GetPrice(datas[i])) //GetPrice(datas[i])
				BuyButtons[i].interactable = false;
			else 
				BuyButtons[i].interactable = true;
		}
		for(int i=0; i<6;i++)
		{
			if(Price_Texts[i].text == "MAX")
				BuyButtons[i].interactable = false;
		}
	
		if(Diamonds < GetPrice_Weapon(weapon))
			BuyButtons[6].interactable = false;
		else 
			BuyButtons[6].interactable = true;

		if(weapon == 6)
			BuyButtons[6].interactable = false;
		
//		LoadSquares();
	}
	
	public string Price_text (int number)
	{
		string temp = "";
		switch (number)
		{
		case 0 :
			temp = "100";
			break;
		case 1 :
			temp = "500";
			break;
		case 2 : 
			temp = "1000";
			break;
		case 3 : 
			temp = "2000";
			break;
		case 4 : 
			temp = "5000";
			break;
		case 5 : 
			temp = "10000";
			break;
		case 6 : 
			temp = "MAX";
			break;
		}
		return temp;
	}
	public string Price_text_weapon (int number)
	{
		string temp = "";
		switch (number)
		{
		case 0 :
			temp = "1000";
			break;
		case 1 :
			temp = "2500";
			break;
		case 2 : 
			temp = "5000";
			break;
		case 3 : 
			temp = "10000";
			break;
		case 4 : 
			temp = "25000";
			break;
		case 5 : 
			temp = "50000";
			break;
		case 6 : 
			temp = "MAX";
			break;
		}
		return temp;
	}
	public int GetPrice_Weapon (int number)
	{
		int temp;
		switch (number)
		{
		case 0 :
			temp = 1000;
			break;
		case 1 :
			temp = 2500;
			break;
		case 2 : 
			temp = 5000;
			break;
		case 3 : 
			temp = 10000;
			break;
		case 4 : 
			temp = 25000;
			break;
		case 5 : 
			temp = 50000;
			break;
		default : 
			temp = 0;
			break;
		}
		return temp;
	}
	public int GetPrice (int number)
	{
		int temp;
		switch (number)
		{
		case 0 :
			temp = 100;
			break;
		case 1 :
			temp = 500;
			break;
		case 2 : 
			temp = 1000;
			break;
		case 3 : 
			temp = 2000;
			break;
		case 4 : 
			temp = 5000;
			break;
		case 5 : 
			temp = 10000;
			break;
		default : 
			temp = 0;
			break;
		}
		return temp;
	}
	public void Buy (int but)
	{
	int upgrade_data = 0;
	string upgrade = "";
	int price = 0;
	switch(but)
		{
		case 0 :
			upgrade = power_str;
			price = GetPrice(power);
			upgrade_data = power;
			break;
		case 1 :
			upgrade = stam_str;
			price = GetPrice(stam);
			upgrade_data = stam;
			break;
		case 2 :
			upgrade = stam_regen_str;
			price = GetPrice(stam_regen);
			upgrade_data = stam_regen;
			break;
		case 3 :
			upgrade = castle_str;
			price = GetPrice(castle);
			upgrade_data = castle;
			break;
		case 4 :
			upgrade = crit_power_str;
			price = GetPrice(crit_power);
			upgrade_data = crit_power;
			break;
		case 5 :
			upgrade = crit_chance_str;
			price = GetPrice(crit_chance);
			upgrade_data = crit_chance;
			break;
		case 6:
			upgrade = weapon_str;
			price = GetPrice_Weapon(weapon);
			upgrade_data = weapon;
			break;
		}

		if((Diamonds >= price)&(upgrade_data < 6))
		{
			MusicManager.instance.PlayMusic(Buy_Button);
			upgrade_data += 1;
			PlayerPrefs.SetInt(upgrade,upgrade_data);
			Diamonds -= price;
			PlayerPrefs.SetInt("Diamonds",Diamonds);
			your_diamonds.text = Diamonds.ToString();
			LoadData();
			LoadPrices();
		}
	}
		
	public void Back ()
	{
		MusicManager.instance.PlayMusic(Arrow_Button);
		second_menu_canvas.SetActive(true);
		gameObject.SetActive(false);
	}
	public void Continue ()
	{
		MusicManager.instance.PlayMusic(Arrow_Button);
		load_screen.SetActive(true);
		PlayerPrefs.SetInt("PlayLoadScreen",1);
		//SceneManager.LoadSceneAsync(1);
		StartCoroutine("LoadCheck");
	}
	public void Shop ()
	{
		MusicManager.instance.PlayMusic(Arrow_Button);
		Shop_Canvas.back_canvas = 3;
		Shop_Object.SetActive(true);
		gameObject.SetActive(false);
	}
	IEnumerator LoadCheck ()
	{
		while (Application.GetStreamProgressForLevel(1) != 1)
		{
			yield return null;
		}
		Resources.UnloadUnusedAssets();
		//SceneManager.LoadSceneAsync(1);
	
		SceneManager.LoadScene(1);
	}

	public void LoadSquares (GameObject[] squares,int number)
	{
		squares[6].transform.position = new Vector3(-100,squares[6].transform.position.y,squares[6].transform.position.z);
		float x;
		for(int i=0;i < 6; i++)
		{
			if(i+1 <= number) 
			{
				squares[i].SetActive(true);
				x = squares[i].transform.position.x;
				squares[6].transform.position = new Vector3(x,squares[6].transform.position.y,squares[6].transform.position.z);
			} else
				squares[i].SetActive(false);
		}
	}
	public void SaveStrings()
	{
		PlayerPrefs.SetString("cur_power",power_str);
		PlayerPrefs.SetString("cur_stamina",stam_str);
		PlayerPrefs.SetString("cur_st_regen",stam_regen_str);
		PlayerPrefs.SetString("cur_castle",castle_str);
		PlayerPrefs.SetString("cur_crit_chance",crit_chance_str);
		PlayerPrefs.SetString("cur_crit_power",crit_power_str);
		PlayerPrefs.SetString("cur_weapon",weapon_str);
	}

	void OnEnable ()
	{
		Debug.Log("OnEnable");

	}
}
