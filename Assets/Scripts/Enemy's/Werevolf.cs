using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Werevolf : Enemy {
	public GameObject health_regen;
	bool regenerating = false;
/*	public Animator myAnim;
	public Collider2D me;

	public GameObject text_poolmanager;
	Dmg_Text_PoolManager text_poolman;

	private int price = 5;
	private int max_health = 250;
	public int current_healt;
	private float speed = 1.5f;
	private float target = -3.3f;
	int Werevolf_dmg = 10;
	public int dmg_taken = Data.heroDmg;

	public GameObject dmg_text_position;
	//Transform meleeTarget;
	// Use this for initialization
*/
	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
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
		price = 50;
		max_health = 550;
		speed = 1.3f;
		target = -2.95f;
		dmg = 40;
		dmg_taken = Data.heroDmg;
		delay_between_attack = 1.1f;
		crit_chance = Data.instance.crit_chance;
		crit_power = Data.instance.crit_power;
		CheckCurrHealth();
	}

	public override void TakeDmg (int dm)
	{
		base.TakeDmg (dm);
		CheckCurrHealth();
	} 

	public void CheckCurrHealth()
	{
		if(current_healt == 0)
			current_healt = max_health;
		if((current_healt <= max_health * 0.5) & !regenerating)
		{
			BeginHealthRegen();
		}
	}
	public void BeginHealthRegen()
	{
		health_regen.SetActive(true);
		StartCoroutine("RegenerateHealth");
		regenerating = true;
	}

	IEnumerator RegenerateHealth ()
	{
		while(current_healt <= max_health * 0.7)
		{
			current_healt += 45;
			yield return new WaitForSeconds(1);
		}
		regenerating = false;
		health_regen.SetActive(false);
	}

	public override void Inactive ()
	{
		StopCoroutine("RegenerateHealth");
		regenerating = false;
		health_regen.SetActive(false);
		base.Inactive ();
	}
		
}

