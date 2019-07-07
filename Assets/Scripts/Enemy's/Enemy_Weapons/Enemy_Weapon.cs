using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Enemy_Weapon : MonoBehaviour {
	public int my_dmg;
	public AudioSource Attack_Music;
	public float time;

	public virtual void TurnOn(Vector3 target,int dmg)
	{
		transform.DOMove(target,time).OnComplete(DoDmg).SetEase(Ease.Linear);
		my_dmg = dmg;
	}
	public void DoDmg ()
	{
		Data.instance.CastleDmg(my_dmg);
		if(PlayerPrefs.GetString("Sound_State") == "ON")
			Attack_Music.Play();
		transform.position = new Vector3 (100,100,0);
		StartCoroutine("Inactive");
		//Attack_Music.Play();
	}
	public IEnumerator Inactive ()
	{
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
	}

}
