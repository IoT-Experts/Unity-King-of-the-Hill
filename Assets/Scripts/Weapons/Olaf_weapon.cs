using UnityEngine;
using System.Collections;

public class Olaf_weapon : Weapon {
	public float RotatePower;
	void Awake ()
	{
		//heroPower = Data.instance.power;
		me = gameObject.GetComponent<Rigidbody2D>();
		if(RotatePower == 0)
			RotatePower = 1.5f;
		string power_str;
		int number;
		power_str = PlayerPrefs.GetString("cur_power");
		number = PlayerPrefs.GetInt(power_str);
		power = power_array2[number];
		//her_choosen = PlayerPrefs.GetInt("HeroChoosen");
	}


	public override void Shoot () 
	{
		me.AddForce(directionShot);
		me.AddTorque((directionShot.magnitude * -1) / (power * RotatePower));
	}
}
