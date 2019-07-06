using UnityEngine;
using System.Collections;

public class HeroSpawner : MonoBehaviour {
//	public GameObject[] Heroes;
	public Transform[] positions;
	GameObject hero;
	int weapon;
	private int curr_hero;
	// Use this for initialization
	void Awake () 
	{
		weapon = PlayerPrefs.GetInt(PlayerPrefs.GetString("cur_weapon"));
		curr_hero = PlayerPrefs.GetInt("HeroChoosen");
		switch(curr_hero)
		{
		case 0:
			switch(weapon)
			{
			case 0:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Olaf/Olaf_0")) as GameObject;
				break;
			case 1:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Olaf/Olaf_1")) as GameObject;
				break;
			case 2:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Olaf/Olaf_2")) as GameObject;
				break;
			case 3:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Olaf/Olaf_3")) as GameObject;
				break;
			case 4:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Olaf/Olaf_4")) as GameObject;
				break;
			case 5:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Olaf/Olaf_5")) as GameObject;
				break;
			case 6:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Olaf/Olaf_6")) as GameObject;
				break;
			}
			hero.transform.position = positions[curr_hero].position;
			break;
		case 1:
			switch(weapon)
			{
			case 0:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Odi/Odi_0")) as GameObject;
				break;
			case 1:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Odi/Odi_1")) as GameObject;
				break;
			case 2:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Odi/Odi_2")) as GameObject;	
				break;
			case 3:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Odi/Odi_3")) as GameObject;
				break;
			case 4:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Odi/Odi_4")) as GameObject;
				break;
			case 5:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Odi/Odi_5")) as GameObject;
				break;
			case 6:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Odi/Odi_6")) as GameObject;
				break;
			}
			hero.transform.position = positions[curr_hero].position;
			break;
		case 2:
			switch(weapon)
			{
			case 0:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Fiona/Fiona_0")) as GameObject;
				break;
			case 1:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Fiona/Fiona_1")) as GameObject;
				break;
			case 2:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Fiona/Fiona_2")) as GameObject;	
				break;
			case 3:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Fiona/Fiona_3")) as GameObject;
				break;
			case 4:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Fiona/Fiona_4")) as GameObject;
				break;
			case 5:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Fiona/Fiona_5")) as GameObject;
				break;
			case 6:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Fiona/Fiona_6")) as GameObject;
				break;
			}
			hero.transform.position = positions[curr_hero].position;
			break;
		case 3:
			switch(weapon)
			{
		case 0:
			hero = Instantiate(Resources.Load("Prefabs/Heroe's/Morgana/Morgana_0")) as GameObject;
			break;
		case 1:
			hero = Instantiate(Resources.Load("Prefabs/Heroe's/Morgana/Morgana_1")) as GameObject;
			break;
		case 2:
			hero = Instantiate(Resources.Load("Prefabs/Heroe's/Morgana/Morgana_2")) as GameObject;	
			break;
		case 3:
			hero = Instantiate(Resources.Load("Prefabs/Heroe's/Morgana/Morgana_3")) as GameObject;
			break;
		case 4:
			hero = Instantiate(Resources.Load("Prefabs/Heroe's/Morgana/Morgana_4")) as GameObject;
			break;
		case 5:
			hero = Instantiate(Resources.Load("Prefabs/Heroe's/Morgana/Morgana_5")) as GameObject;
			break;
		case 6:
			hero = Instantiate(Resources.Load("Prefabs/Heroe's/Morgana/Morgana_6")) as GameObject;
			break;
			}
			hero.transform.position = positions[curr_hero].position;
			break;
		case 4:
			switch(weapon)
			{
			case 0:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Maximus/Maximus_0")) as GameObject;
				break;
			case 1:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Maximus/Maximus_1")) as GameObject;
				break;
			case 2:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Maximus/Maximus_2")) as GameObject;	
				break;
			case 3:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Maximus/Maximus_3")) as GameObject;
				break;
			case 4:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Maximus/Maximus_4")) as GameObject;
				break;
			case 5:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Maximus/Maximus_5")) as GameObject;
				break;
			case 6:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/Maximus/Maximus_6")) as GameObject;
				break;
			}
			hero.transform.position = positions[curr_hero].position;
			break;
		case 5:
			switch(weapon)
			{
			case 0:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/BOOM-BOOM/BOOM-BOOM_0")) as GameObject;
				break;
			case 1:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/BOOM-BOOM/BOOM-BOOM_1")) as GameObject;
				break;
			case 2:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/BOOM-BOOM/BOOM-BOOM_2")) as GameObject;	
				break;
			case 3:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/BOOM-BOOM/BOOM-BOOM_3")) as GameObject;
				break;
			case 4:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/BOOM-BOOM/BOOM-BOOM_4")) as GameObject;
				break;
			case 5:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/BOOM-BOOM/BOOM-BOOM_5")) as GameObject;
				break;
			case 6:
				hero = Instantiate(Resources.Load("Prefabs/Heroe's/BOOM-BOOM/BOOM-BOOM_6")) as GameObject;
				break;
			}
			hero.transform.position = positions[curr_hero].position;
			break;

		}
		//Instantiate(Heroes[curr_hero],positions[curr_hero].position,Quaternion.identity);
	}

}
