using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Tree_Beast : Enemy {

	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
	}

	public void AssignValues()
	{
		points = 75;
		price = 5;
		max_health = 65;
		speed = 1.4f;
		target = -3.35f;
		dmg = 25;
		dmg_taken = Data.heroDmg;
		delay_between_attack = 1.0f;
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
		if(dmg_taken == 0)
		{
			dmg_taken = 30;
		}
		//current_healt = max_health;
		transform.DOMoveX(target,time()).OnComplete(PrepareToAttack).SetEase(Ease.Linear);
	}
}
