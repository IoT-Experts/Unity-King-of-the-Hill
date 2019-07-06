using UnityEngine;
using System.Collections;

public class Fiona_weapon : Weapon {

	void Awake ()
	{
		me = gameObject.GetComponent<Rigidbody2D>();
		//her_choosen = PlayerPrefs.GetInt("HeroChoosen");
		//heroPower = Data.instance.power;
		me.centerOfMass = center_mass.transform.localPosition;
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
	public override void TurnOn ()
	{
		me.rotation = Vector2.Angle(Vector2.right,new Vector2(EventManager.Napram.x,EventManager.Napram.y));
		base.TurnOn ();
	}
}