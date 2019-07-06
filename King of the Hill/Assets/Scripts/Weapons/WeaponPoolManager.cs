using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponPoolManager : MonoBehaviour {
	List<GameObject> weapon_list = new List<GameObject>();
	//список зброі
	public GameObject weapon;
	//сама зброя
	private int weapon_count = 3;
	private int hero_choosen;
	void Awake ()
	{
		for(int i=0; i < weapon_count;i++)
		{
			GameObject temp = (GameObject)Instantiate(weapon);
			temp.transform.SetParent(transform);
			temp.SetActive(false);
			weapon_list.Add(temp);
			//Debug.Log("Weapon Added");
		}
		hero_choosen = PlayerPrefs.GetInt("HeroChoosen");
	//	Debug.Log("HEROOO CHOOSEN");
	//	Debug.Log(hero_choosen);
	}
	public void AddWeapons ()
	{
		for(int i=0; i < 3;i++)
		{
			GameObject temp = (GameObject)Instantiate(weapon);
			temp.transform.SetParent(transform);
			temp.SetActive(false);
			weapon_list.Add(temp);
		}
	}

	public void LaunchWapon(GameObject Caller,Transform ShootPos)
	{
		if(weapon_list != null);
		{
			for(int i = 0;i < weapon_list.Count;i++)
			{
				/*тут перевіряєм чи обєкт не є активний
				 * якшо неактивний берем його
				 * в іншому разі рухаємось далі */
				if(!weapon_list [i].activeInHierarchy)
				{
					weapon_list[i].SetActive(true);
					weapon_list[i].transform.position = ShootPos.position;
					weapon_list[i].GetComponent<Weapon>().TurnOn();
					//треба повісити на обєкт деактиватор
					break;
				}
				else if(i == weapon_list.Count -1)
				{
					AddWeapons();
					LaunchWapon(Caller,ShootPos);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
