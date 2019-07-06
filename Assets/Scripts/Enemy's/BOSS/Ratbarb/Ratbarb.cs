using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Ratbarb : MonoBehaviour {
	
	public Animator myAnim;
	public EdgeCollider2D armor;

	public GameObject text_poolmanager;
	public Dmg_Text_PoolManager text_poolman;

	public EnemySpawner enemy_spawn;
	public GameObject enemy_spawner;
	public AudioClip Death_Sound;
	public AudioClip Attack_Sound;
	public AudioClip Armor_Sound;
	public AudioSource me_music;
	bool dead;

	int points;
	float delay_between_attack;
	int price;
	int max_health;
	int current_healt;
	float speed;
	float target;
	int dmg;
	int dmg_taken = Data.heroDmg;
	public GameObject dmg_text_position;
	int crit_chance;
	float crit_power;
	bool crit;

	void Awake ()
	{
		text_poolmanager = GameObject.Find("Dmg_Text_Generator");
		text_poolman = text_poolmanager.GetComponent<Dmg_Text_PoolManager>();
		enemy_spawner = GameObject.Find("EnemySpawner");
		enemy_spawn = enemy_spawner.GetComponent<EnemySpawner>();
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

	public void LaunchEnemySpawn ()
	{
		enemy_spawn.AfterBossLaunch(false);
	}

	public void AssignValues()
	{
		if(BossMultiplicator.Multiplicator == 1)
			points = 100;
		else
			points = 150 * BossMultiplicator.Multiplicator;
		if(BossMultiplicator.Multiplicator == 1)
			price = 50 * BossMultiplicator.Multiplicator;
		else 
			price = 80 * BossMultiplicator.Multiplicator;

		if(BossMultiplicator.Multiplicator == 1)
			max_health = 200;
		else 
			max_health = 450 * BossMultiplicator.Multiplicator;
		
		if(BossMultiplicator.Multiplicator == 1)
			dmg = 20;
		else 
			dmg = 40 * BossMultiplicator.Multiplicator;
		speed = 1.0f;
		target = -2.15f;
		//dmg = 15 * BossMultiplicator.Multiplicator; //* (BossMultiplicator.Multiplicator + 1) ;
		dmg_taken = Data.heroDmg;
		delay_between_attack = 1.7f;
		crit_chance = Data.instance.crit_chance;
		crit_power = Data.instance.crit_power;
		CheckCurrHealth();
	}

	public void CheckCurrHealth()
	{
		if(current_healt == 0)
			current_healt = max_health;
	}
	public void Become_Normal()
	{
		AssignValues();
		dead = false;
		current_healt = max_health;
		transform.DOMoveX(target,time()).OnComplete(PrepareToAttack).SetEase(Ease.Linear);

	}

	public void PrepareToAttack ()
	{
		transform.DOKill();
		StartCoroutine("Attack_cor");
		myAnim.SetTrigger("Prepare");
	}

	public float time ()
	{
		float dist = transform.position.x - target;
		return dist/speed;
	}
	IEnumerator Attack_cor ()
	{
		Debug.Log("Start AttackCor");
		yield return new WaitForSeconds(delay_between_attack);
		while(true)
		{
			Debug.Log("WHileTrue");
			myAnim.SetTrigger("Attack");
			yield return new WaitForSeconds(delay_between_attack);
		}
	}

	public virtual void DoDmg ()
	{
		Data.instance.CastleDmg(dmg);
		PlayAttackMusic();
	}
	public bool CritCheck (int chance)
	{
		int number;
		number = Random.Range(0,101);
		if(chance >= number)
			return true;
		else 
			return false;
	}
	public virtual void TakeDmg(int dm)
	{
		crit = CritCheck(crit_chance);
		Debug.Log("DMG - " + dm);
		if(crit)
			dm = (int)(dm * crit_power);
		Debug.Log("After crit " + dm);

		text_poolman.LaunchText(dmg_text_position,dm,crit);
		current_healt -= dm;

		if (current_healt <= 0 )
		{
			//me.isTrigger = true;
			//CancelInvoke("Attack");
			StopCoroutine("Attack_cor");
			transform.DOKill();
			PlayDeathMusic();
			if(!dead)
			{
				Data.instance.boss_slayed++;
				dead = true;
			}
			myAnim.SetTrigger("Death");
			Data.instance.AddDiamond(price);
			Data.instance.AddPoints(points);
			//Inactive();
		}
	}

	public virtual void Inactive()
	{
		myAnim.SetTrigger("AfterDeath");
		gameObject.SetActive(false);
		BossMultiplicator.Multiplicator++;
		transform.position = new Vector3 (11.27f,-3.3f,0);
		LaunchEnemySpawn();
	}
	public void Prep ()
	{
		myAnim.SetTrigger("PrepareTo");
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.tag == "Weapon")
		{
			ArmorHit();
			coll.gameObject.SetActive(false);

		}
	}
	public void ArmorHit()
	{
		TakeDmg(1);
		if(PlayerPrefs.GetString("Sound_State") == "ON")
		{
			me_music.clip = Armor_Sound;
			me_music.Play();
		}
	}
	public void DetailHit()
	{
		TakeDmg(dmg_taken);
	}

	public void PlayAttackMusic()
	{
		if(PlayerPrefs.GetString("Sound_State") == "ON")
		{
			me_music.clip = Attack_Sound;
			me_music.Play();
		}
	}
	public void PlayDeathMusic()
	{
		if(!dead)
		{
		if(PlayerPrefs.GetString("Sound_State") == "ON")
		{
			me_music.clip = Death_Sound;
			me_music.Play();
		}
		}
	}
}
