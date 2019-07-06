using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Witch_BOSS : RangeEnemy {

	public BeastSpawner beast_spawner;
	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();	
	}

	public void AssignValues()
	{
		points = 250 * (BossMultiplicator.Multiplicator - 2);
		price = 120 * (BossMultiplicator.Multiplicator - 2);
		max_health = 800 * (BossMultiplicator.Multiplicator - 2);
		speed = 1.7f;
		target = 3.5f;
		dmg = 75 * (BossMultiplicator.Multiplicator - 2);
		dmg_taken = Data.heroDmg;
		delay_between_attack = 1.9f;
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

	public void SpawnBeast()
	{
		beast_spawner.LaunchEnemy(transform.position,true);
	}

	public override void TakeDmg (int dm)
	{
		crit = CritCheck(crit_chance);
		if(crit)
			dm = (int)(dm * crit_power);

		text_poolman.LaunchText(dmg_text_position,dm,crit);
		current_healt -= dm;

		if (current_healt <= 0 )
		{
			me.isTrigger = true;
			//CancelInvoke("Attack");
			StopCoroutine("Attack_cor");
			transform.DOKill();
			myAnim.SetTrigger("Death");
			PlayDeathMusic();
			Data.instance.AddMonsters();
			Data.instance.AddDiamond(price);
			Data.instance.AddPoints(points);
			//Inactive();
		}
	}
}
