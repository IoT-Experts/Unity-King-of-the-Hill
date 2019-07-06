using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Boss_Pool_Manager : MonoBehaviour {
	
	List<GameObject> claw_enemy_list = new List<GameObject>();
	//список ворогів з рогами
	public GameObject claw_enemy;
	//саме рогатий ворог
	private int claw_enemy_count= 1;

	void Awake ()
	{
		for(int i=0; i < claw_enemy_count;i++)
		{
			GameObject temp = (GameObject)Instantiate(claw_enemy);
			temp.transform.SetParent(transform);
			temp.SetActive(false);
			claw_enemy_list.Add(temp);
		}
	}

	public void AddEnemies ()
	{
		for(int i=0; i < 3;i++)
		{
			GameObject temp = (GameObject)Instantiate(claw_enemy);
			temp.transform.SetParent(transform);
			temp.SetActive(false);
			claw_enemy_list.Add(temp);
		}
	}

	public void LaunchEnemy(Vector3 Caller)
	{
		if(claw_enemy_list != null)
		{
			for(int i = 0;i < claw_enemy_list.Count;i++)
			{

				/*тут перевіряєм чи обєкт не є активний
				 * якшо неактивний берем його
				 * в іншому разі рухаємось далі */
				if(!claw_enemy_list[i].activeInHierarchy)
				{
					claw_enemy_list[i].SetActive(true);
					claw_enemy_list[i].transform.position = Caller;
					claw_enemy_list[i].GetComponent<Ratbarb>().Become_Normal();
					//треба повісити на обєкт деактиватор
					break;
				}
				else if(i == claw_enemy_list.Count -1)
				{
					AddEnemies();
					LaunchEnemy(Caller);
				}
			}
		} 
	}
}
