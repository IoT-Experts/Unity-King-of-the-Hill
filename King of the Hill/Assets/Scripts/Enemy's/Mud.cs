using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Mud : RangeEnemy {
	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
		Attack_Sound = null;
	}
	public AudioClip blorp;

	public void AssignValues()
	{
		points = 12;
		price = 4;
		max_health = 28;
		speed = 1.0f;
		target = -1.35f;
		dmg = 3;
		dmg_taken = Data.heroDmg;
		delay_between_attack = 1.8f;
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
	public void DooDmg () //!!
	{
		base.DoDmg ();
		//PlayAttackMusic();
	}
	public override void TakeDmg (int dm)
	{
		int random_number;
		random_number = UnityEngine.Random.Range(1,11);
		if(random_number > 1)
		{
			base.TakeDmg (dm);
		}
		else
		{
			PlayBlorpMusic();
		}
	}
	public void PlayBlorpMusic ()
	{
		if(PlayerPrefs.GetString("Sound_State") == "ON")
		{
			me_music.clip = blorp;
			me_music.Play();
		}
	}

}
