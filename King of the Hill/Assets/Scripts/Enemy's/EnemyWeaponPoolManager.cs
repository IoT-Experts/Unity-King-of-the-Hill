using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyWeaponPoolManager : MonoBehaviour {
	
	List<GameObject> weapon_list = new List<GameObject>();
	//список зброі
	public GameObject weapon;
	public GameObject enemy_weapon_handler;
	Transform weapon_handler;
	//сама зброя
	private int weapon_count = 3;
	private int hero_choosen;
	void Awake ()
	{
		enemy_weapon_handler = GameObject.FindWithTag("Finish");
		weapon_handler = enemy_weapon_handler.GetComponent<Transform>();
		hero_choosen = PlayerPrefs.GetInt("HeroChoosen");

		for(int i=0; i < weapon_count;i++)
		{
			GameObject temp = (GameObject)Instantiate(weapon);
			temp.SetActive(false);
			weapon_list.Add(temp);
			temp.transform.SetParent(weapon_handler);
			//Debug.Log("Weapon Added");
		}

		//	Debug.Log("HEROOO CHOOSEN");
		//	Debug.Log(hero_choosen);
	}

	public void AddWeapons ()
	{
		for(int i=0; i < 3;i++)
		{
			GameObject temp = (GameObject)Instantiate(weapon);
			temp.transform.SetParent(weapon_handler);
			temp.SetActive(false);
			weapon_list.Add(temp);
		}
	}

	public void LaunchWeapon(GameObject Caller,Transform ShootPos,Vector3 target,int dmg)
	{
		if(weapon_list != null);
		{
			for(int i = 0;i < weapon_count;i++)
			{
				/*тут перевіряєм чи обєкт не є активний
				 * якшо неактивний берем його
				 * в іншому разі рухаємось далі */
				if(!weapon_list [i].activeInHierarchy)
				{
					weapon_list[i].SetActive(true);
					weapon_list[i].transform.position = ShootPos.position;
					weapon_list[i].GetComponent<Enemy_Weapon>().TurnOn(target,dmg);
					//треба повісити на обєкт деактиватор
					break;
				}
				else if(i == weapon_list.Count -1)
				{
					AddWeapons();
					LaunchWeapon(Caller,ShootPos,target,dmg);
				}
			}
		}
	}

}
