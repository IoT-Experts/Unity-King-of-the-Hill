using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour {
	public EnemyPoolManager enemy_system;
	public EnemyPoolManager[] enemy1;
	public EnemyPoolManager[] enemy2;
	public EnemyPoolManager[] enemy3;
	public EnemyPoolManager[] enemy4;
	public EnemyPoolManager[] enemy5;
	public EnemyPoolManager[] enemy6;
	public EnemyPoolManager[] EnemySpawning;
	List<EnemyPoolManager> Enemy_Spawning = new List<EnemyPoolManager>();

	public Boss_Pool_Manager Ratbarb_Spawner;
	public Witch_BOSS_Pool_Manager Witch_BOSS_Spawner;
	public Trol_Pool_Manager Trol_Spawner;
	public TreeSpawner Tree_Spawner;
	public Transform ratbarb_spawn_position;
	public Transform trol_spawn_position;
	public GameObject WitchPosition_top;
	public GameObject WitchPosition_bottom;
	public GameObject Fluffy_Spawn_Pos;
	public GameObject Raven_Spawn_Pos;
	public GameObject Claw_Spawn_Pos;
	Vector3 my_pos;
	int[] enemies_types;
	int points;
	int curr_wave;
	int difficulty;
	int enemy_amount;
	int max_powerOfEnemy = 6;
	int current_powerOfEnemy;
	float delay_between_enemys = 2.3f;
	float delay_between_waves = 3.0f;
	float max_delay = 4.0f;
	int cur_bos;
	// Use this for initialization

	void GenerateWave ()
	{
		int i;
		enemies_types = new int[enemy_amount];
		i = 0;
		points = difficulty;
		while(i < enemy_amount)
		{
			if(points > 0)
			{
				enemies_types[i] = UnityEngine.Random.Range(1,Mathf.Min(current_powerOfEnemy,points) + 1);
				points -= enemies_types[i];
			}
			i++;
		}
		for (int j = 0; j < 3; j++)
		{
		if(points > 0) //lets make this wave stronger , btw we have some point to use ;)
		{ 
			i = 0; //again iterations 
			while(i < enemy_amount)
			{
				if(points > 0) //we need to check if we still have points
				{
					enemies_types[i] += UnityEngine.Random.Range(1,Mathf.Min(current_powerOfEnemy - enemies_types[i],points) + 1); //lets make this enemy a bit stronger
					enemies_types[i] = Mathf.Min(current_powerOfEnemy,enemies_types[i]);
					points -= enemies_types[i]; //if you put enemies you spend points
				}
				i++; //lets iterate more
			}
		}
		}
		/*string st = "";
		for(i=0 ; i< enemy_amount; i++)
		{
			st += enemies_types[i].ToString() + " ";
		}
		Debug.Log(st); */
		GenerateSpawningArray();

	}
	void GenerateSpawningArray ()
	{
		//int size_of_array;
		EnemySpawning = new EnemyPoolManager[enemy_amount];
		EnemyPoolManager[] temp = new EnemyPoolManager[2];
		for(int i = 0; i<enemy_amount; i++)
		{
			switch(enemies_types[i])
			{
				case 0 :
					temp = null;
					break;
				case 1 : 
					temp = enemy1;
					break;
				case 2 : 
					temp = enemy2;
					break;
				case 3 :
					temp = enemy3;
					break;
				case 4 :
					temp = enemy4;
					break;
				case 5 :
					temp = enemy5;
					break;
				case 6 :
					temp = enemy6;
					break;
			}
			if(temp != null)
			{
			int number = UnityEngine.Random.Range(0,temp.Length);
			EnemySpawning[i] = temp[number];
		
			}

		}
		StartCoroutine("LaunchEnemies");
		//StopCoroutine("SpawnEnemyBegin");
	}
	IEnumerator LaunchEnemies()
	{
		int i = 0;
		while(i < EnemySpawning.Length)
		{
			if(EnemySpawning[i] != null)
			{
				switch(EnemySpawning[i].name)
				{
				case "Witch_Spawner":
					Vector3 pos = new Vector3();
					pos = WitchPosition_top.transform.position;
					float top = WitchPosition_top.transform.position.y;
					float bottom = WitchPosition_bottom.transform.position.y;
					pos.y = UnityEngine.Random.Range(WitchPosition_bottom.transform.position.y,WitchPosition_top.transform.position.y);
					EnemySpawning[i].LaunchEnemy(pos);
					break;
				case "Fluffy_Spawner":
					EnemySpawning[i].LaunchEnemy(Fluffy_Spawn_Pos.transform.position);
					break;
				case "Raven_Spawner":
					EnemySpawning[i].LaunchEnemy(Raven_Spawn_Pos.transform.position);
					break;
				case "ClawEnemySpawner":
					EnemySpawning[i].LaunchEnemy(Claw_Spawn_Pos.transform.position);
					break;
				default :
					EnemySpawning[i].LaunchEnemy(my_pos);
					break;
				}
			/*	if(EnemySpawning[i].name == "Witch_Spawner")
				{
					Vector3 pos = new Vector3();
					pos = WitchPosition_top.transform.position;
					float top = WitchPosition_top.transform.position.y;
					float bottom = WitchPosition_bottom.transform.position.y;
					pos.y = UnityEngine.Random.Range(WitchPosition_bottom.transform.position.y,WitchPosition_top.transform.position.y);
					EnemySpawning[i].LaunchEnemy(pos);
				} else
				{
					EnemySpawning[i].LaunchEnemy(my_pos);
				} */
			}
			i++;
			yield return new WaitForSeconds(delay_between_enemys);	
		}
		StartCoroutine("SpawnEnemyBegin",delay_between_waves);
		yield return null;

	}
	void Start ()
	{
		cur_bos = 1;
		BossMultiplicator.Multiplicator = 1;
		my_pos = transform.position;
		difficulty = 6;
		enemy_amount = 6;
		current_powerOfEnemy = 1; //мало бути 1
		//GenerateWave();
		StartCoroutine("SpawnEnemyBegin",4.0f);

	}
	IEnumerator SpawnEnemyBegin (float delay)
	{
		yield return new WaitForSeconds(delay);
		//while (true)
		//{
			if((difficulty -5)%5 == 0) //5
			{
				LaunchBoss();
				difficulty += 5;
				enemy_amount++;
			}
			else
			{
				GenerateWave();
			}
			
			//GenerateSpawningArray();
			//LaunchEnemies();
			//запустит їх потім
			difficulty ++;
			if((difficulty - 6)%5 == 0)  //мало бути 3
			{
				
				current_powerOfEnemy++;
				delay_between_waves += 0.2f;
				delay_between_waves = Mathf.Min(delay_between_waves,max_delay);
				current_powerOfEnemy = Mathf.Min(current_powerOfEnemy,max_powerOfEnemy);
			}
		if((difficulty - 3)%3 == 0)
		{
			enemy_amount++;
		}
			//yield return new WaitForSeconds(delay_between_waves);
		//}
	}
	public void LaunchBoss()
		{
			switch(cur_bos%4)
			{
				case 1:
				Ratbarb_Spawner.LaunchEnemy(ratbarb_spawn_position.position);
				cur_bos++;
				break;
				case 2: 
				Trol_Spawner.LaunchEnemy(trol_spawn_position.position,false);
				cur_bos++;
				break;
				case 3: 
					Witch_BOSS_Spawner.LaunchEnemy(Witch_BOSS_Spawner.transform.position);
					cur_bos++;
					break;
				case 0:
				Tree_Spawner.LaunchEnemy(Tree_Spawner.transform.position);
				cur_bos++;
				break;
			}

		}
	public void AfterBossLaunch(bool multiplicate)
	{
		if(multiplicate)
			BossMultiplicator.Multiplicator++;
		StartCoroutine("SpawnEnemyBegin",3.0f);
	}
}
