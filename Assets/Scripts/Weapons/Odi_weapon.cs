using UnityEngine;
using System.Collections;

public class Odi_weapon : Weapon {
	void Awake ()
	{
		//heroPower = Data.instance.power;
		me = gameObject.GetComponent<Rigidbody2D>();
		power = power_array2[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_power"))];
		//her_choosen = PlayerPrefs.GetInt("HeroChoosen");
	}


}
