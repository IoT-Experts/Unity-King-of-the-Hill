using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Raven : Enemy {
	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
	}

	public void AssignValues()
	{
		points = 18;
		price = 15;
		max_health = 45;
		speed = 1.8f;
		target = -7.7f; //7.8
		dmg = 55;
		dmg_taken = Data.heroDmg;
		delay_between_attack = 0;
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

	public void Falling()
	{
		//StartCoroutine("Fall");
		transform.DOMoveY(transform.position.y - 3,1.0f).SetEase(Ease.Linear);
	}
	IEnumerator Fall ()
	{
		while(true)
		{
			transform.position -= Vector3.down * Time.deltaTime * 5;
		}
	}
	public override void Inactive ()
	{
		transform.DOKill();
		base.Inactive ();
		//StopCoroutine("Fall");
	}
}
