using UnityEngine;
using System.Collections;

public class Maximus_weapon : Weapon {

	void Awake ()
	{
		me = gameObject.GetComponent<Rigidbody2D>();
		//her_choosen = PlayerPrefs.GetInt("HeroChoosen");
		//heroPower = Data.instance.power;
		power = power_array2[PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_power"))];

	}
	void FixedUpdate()
	{
		if(me.velocity != Vector2.zero)
		{
			me.rotation =  Mathf.Sign(me.velocity.y)*Vector2.Angle(Vector2.right,me.velocity);
		}
		//my.transform.LookAt(transform.position + me.velocity);
	}
}