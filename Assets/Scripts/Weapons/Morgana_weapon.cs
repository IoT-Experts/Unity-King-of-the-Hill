using UnityEngine;
using System.Collections;

public class Morgana_weapon : Weapon {
	void Awake ()
	{
		//heroPower = Data.instance.power;
		me = gameObject.GetComponent<Rigidbody2D>();
		power = power_array2[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_power"))];
		//her_choosen = PlayerPrefs.GetInt("HeroChoosen");
	}


	new public void Shoot () 
	{
		me.AddForce(directionShot);
		me.AddTorque(directionShot.magnitude / power * 0.6f * -1);
	}
}
