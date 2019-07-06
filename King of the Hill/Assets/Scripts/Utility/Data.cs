using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Data : MonoBehaviour {
	public static int CastleHealth;
	public static int heroDmg;
	bool death = false;
	public GameObject CastleDestroy;
	public GameObject[] castles;
	//public static float power;

	public static Data instance = null;
	//********************************
	//Дані нашої гри 
	public int[] castle_max_healt_array = {100,200,400,600,1000,1500,2000};
	public int[] stamina_max_array1 = {100,110,125,150,175,200,230};
	public int[] stam_regen_array2 = {15,16,17,19,21,23,25};
	public int[] crit_chance_array1 = {0,5,10,15,20,25,30};
	public float[] crit_power_array1 = {1.25f,1.5f,1.75f,2.0f,2.3f,2.6f,3.0f};
	public int[] power_array1 = {10,11,12,13,14,15,16};
	//Дані обявлено
	//**************************************
	public int diamonds_collected;
	public int points_collected;
	public string curr_points_str,max_points_str;
	public float time;
	public int monsters_slayed;
	public int headshots;
	public int boss_slayed;
	public GameObject after_death_menu;
	public Time_Handler time_handler;
	public Text textCastlHealth;
	public Text curr_diam_text;

	public int max_health;
	public int max_stamina;
	public int st_regen;
	public int crit_chance = 0;
	public float crit_power = 1.5f;
	public int power;
	public int weapon;

	public AudioClip Lose_Sound;
	// Use this for initialization
	void Awake ()
	{
		death = false;
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    

		//heroDmg = 45;
		diamonds_collected = 0;
		monsters_slayed = 0;
		headshots = 0;
		boss_slayed = 0;
		points_collected = 0;
		//DontDestroyOnLoad(gameObject);
		LoadData();
		StartCoroutine("Recour");
	}

	IEnumerator Recour ()
	{
		while(true)
		{
			yield return new WaitForSeconds(5.0f);
			Resources.UnloadUnusedAssets();
		}
	}
	public void LoadData()
	{
		max_health = castle_max_healt_array[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_castle"))];
		max_stamina = stamina_max_array1[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_stamina"))];
		st_regen = stam_regen_array2[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_st_regen"))];
		crit_chance = crit_chance_array1[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_crit_chance"))];
		crit_power = crit_power_array1[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_crit_power"))];
	
		weapon = PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_weapon"));
		int base_dmg = 0;
		int multiplicator = 0;
		switch(PlayerPrefs.GetInt("HeroChoosen"))
		{
		case 0:
			base_dmg = 28;
			multiplicator = 9;
			break;
		case 1:
			base_dmg = 25;
			multiplicator = 7;
			break;
		case 2:
			base_dmg = 22;
			multiplicator = 5;
			break;
		case 3:
			base_dmg = 23;
			multiplicator = 6;
			break;
		case 4:
			base_dmg = 26;
			multiplicator = 8;
			break;
		case 5:
			base_dmg = 30;
			multiplicator = 10;
			break;
		}
		heroDmg = base_dmg + weapon*multiplicator;

	//	power = power_array[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_power"))];

	}
	void Start ()
	{
		MusicManager.instance.AssignBackground();
		CastleHealth = max_health;
		castles[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_castle"))].SetActive(true);

		textCastlHealth.text = CastleHealth.ToString();
		curr_diam_text.text = "0";
	}

	public void CastleDmg (int dmg)
	{
		CastleHealth -=dmg;
		if(CastleHealth <= 0) 
			Lose();
		if(!death)
			ChangeCastleHealth(CastleHealth.ToString());
	}

	public void Lose()
	{
		death = true;
		textCastlHealth.text = "0";
		MusicManager.instance.Background.Stop();
		MusicManager.instance.Stop_Exhaust();
		MusicManager.instance.PlayMusic(Lose_Sound);
		MusicManager.instance.lose = true;
		CastleDestroy.SetActive(true);


	}
	public void CastleDestroyed ()
	{
		Time.timeScale = 0.0f;
		CastleHealth = 0;
		MusicManager.instance.lose = false;
		if(PlayerPrefs.GetString("Doubler") == "Have")
			diamonds_collected *= 2;
		after_death_menu.SetActive(true);
		AddMoney();
		CheckPoints();	
	}
	public void CheckPoints()
	{
		int multiplicator;
		multiplicator = time_handler.ReturnMinutes() + 1;
		points_collected *= multiplicator;
		if(points_collected > PlayerPrefs.GetInt("Max_Points"))
		{
			PlayerPrefs.SetInt("Max_Points",points_collected);
			curr_points_str = "NEW RECORD";
			max_points_str = points_collected.ToString();	
		} else 
		{
			curr_points_str = points_collected.ToString();
			max_points_str = PlayerPrefs.GetInt("Max_Points").ToString();
		}
	}

	public void AddMoney()
	{
		int temp;
		temp = PlayerPrefs.GetInt("Diamonds");
		temp += diamonds_collected;
		PlayerPrefs.SetInt("Diamonds",temp);
	}

	public void ChangeCastleHealth(string str)
	{
		textCastlHealth.text = str;
	}

	public void AddDiamond (int dia)
	{
		diamonds_collected += dia;
		ChangeDiaText();
	}
	public void ChangeDiaText ()
	{
		curr_diam_text.text = diamonds_collected.ToString();
	}
	public void AddPoints (int points)
	{
		points_collected += points;
	}

	public void AddMonsters ()
	{
		monsters_slayed ++;
	}

	public void AddHeadshots ()
	{
		headshots ++;
	}
	

}
