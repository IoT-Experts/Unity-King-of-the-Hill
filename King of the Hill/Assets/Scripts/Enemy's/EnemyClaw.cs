using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EnemyClaw : Enemy {
/*	public Animator myAnim;
	public Collider2D me;

	public GameObject text_poolmanager;
	Dmg_Text_PoolManager text_poolman;

	private int price = 3;
	private int max_health = 50;
	public int current_healt;
	private float speed = 1.25f;
	private float target = -3.4f;
	int enemyClawDmg = 5;
	public int dmg_taken = Data.heroDmg;

	public GameObject dmg_text_position;
	//Transform meleeTarget;
*/
	// Use this for initialization
	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
	}

	public void AssignValues()
	{
		points = 10;
		price = 3;
		max_health = 20;
		speed = 1.25f;
		target = -3.0f; //3.4
		dmg = 5;
		dmg_taken = Data.heroDmg;
		delay_between_attack = 1.2f;
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
