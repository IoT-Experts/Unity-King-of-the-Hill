using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Fluffy : RangeEnemy {

	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();	
	}

	public void AssignValues()
	{
		points = 25;
		price = 12;
		max_health = 55;
		speed = 1.15f;
		target = -0.65f;
		dmg = 15;
		dmg_taken = Data.heroDmg;
		delay_between_attack = 1.5f;
		crit_chance = Data.instance.crit_chance;
		crit_power = Data.instance.crit_power;
		CheckCurrHealth();
	}
	public void CheckCurrHealth()
	{
		if(current_healt == 0)
			current_healt = max_health;
	}

	void Start () 
	{
		AssignValues();
		dmg_taken = Data.heroDmg;
		//current_healt = max_health;
		transform.DOMoveX(target,time()).OnComplete(PrepareToAttack).SetEase(Ease.Linear);
	}

	public void DooDmg ()
	{
		base.DoDmg();
	}

}
