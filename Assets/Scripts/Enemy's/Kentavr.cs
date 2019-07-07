using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Kentavr : Enemy {

	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
	}

	public void AssignValues()
	{
		points = 55;
		price = 35;
		max_health = 245;
		speed = 2.5f;
		target = -2.65f;
		dmg = 28;
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


	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
