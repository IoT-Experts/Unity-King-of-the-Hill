using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Enemy : MonoBehaviour {
	public Animator myAnim;
	public Collider2D me;

	public GameObject text_poolmanager;
	public Dmg_Text_PoolManager text_poolman;

	public AudioClip Death_Sound;
	public AudioClip Attack_Sound;
	public AudioSource me_music;

	public int points;
	public float delay_between_attack;
	public int price;
	public int max_health;
	public int current_healt;
	public float speed;
	public float target;
	public int dmg;
	public int dmg_taken = Data.heroDmg;
	public GameObject dmg_text_position;
	public int crit_chance;
	public float crit_power;
	public bool crit;
	// Use this for initialization
	public void Become_Normal()
	{
		me.isTrigger = false;
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
		yield return new WaitForSeconds(delay_between_attack);
		while(true)
		{
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

	public virtual void Inactive()
	{
		myAnim.SetTrigger("AfterDeath");
		gameObject.SetActive(false);
		transform.position = new Vector3 (11.27f,-3.3f,0);

	}
	public void Prep ()
	{
		myAnim.SetTrigger("PrepareTo");
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.tag == "Weapon")
		{
			TakeDmg(dmg_taken);
			coll.gameObject.SetActive(false);

		}
	}

	public void PlayAttackMusic()
	{
		if(PlayerPrefs.GetString("Sound_State") == "ON")
		{
		me_music.clip = Attack_Sound;
		me_music.Play();
		} 
		else
		{
			Debug.Log("BUM");
		}
	}
	public void PlayDeathMusic()
	{
		if(PlayerPrefs.GetString("Sound_State") == "ON")
		{
			me_music.clip = Death_Sound;
			me_music.Play();
		}
	}

}
