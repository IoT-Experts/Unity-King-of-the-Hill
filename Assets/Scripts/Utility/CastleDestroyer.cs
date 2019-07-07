using UnityEngine;
using System.Collections;

public class CastleDestroyer : MonoBehaviour {
	public Data dat;
	public GameObject castle;
	GameObject hero;
	public GameObject EnemySpawner;
	public GameObject green_stripe;
	// Use this for initialization
	void Start ()
	{
		hero = GameObject.FindGameObjectWithTag("Player");
	}
	public void Destroy ()
	{
		dat.CastleDestroyed();
	}
	public void HideCastle ()
	{
		castle.SetActive(false);
	}
	public void HideHeroEnemy ()
	{
		hero.SetActive(false);
		EnemySpawner.SetActive(false);
		green_stripe.SetActive(false);
	}
}
