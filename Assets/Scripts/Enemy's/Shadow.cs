using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Shadow : RangeEnemy {

	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
		Attack_Sound = null;
	}
	void Start () 
	{
		AssignValues();
		dmg_taken = Data.heroDmg;
		if(dmg_taken == 0)
		{
			dmg_taken = 30;
		}
		//current_healt = max_health;
		transform.DOMoveX(target,time()).OnComplete(PrepareToAttack).SetEase(Ease.Linear);
	}


	public void AssignValues()
	{
		points = 100;
		price = 85;
		max_health = 800;
		speed = 1.15f;
		target = 1.25f;
		dmg = 70;
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

	public void DooDmg ()
	{
		base.DoDmg();
		LifeSteal();
	}
	void LifeSteal ()
	{
		if(current_healt <= max_health - 55)
		{
			current_healt += 70;
		}
	}
}
