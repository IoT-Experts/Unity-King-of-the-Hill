using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Dmg_Text_PoolManager : MonoBehaviour {

	List<GameObject> text_list = new List<GameObject>();
	//список зброі
	public GameObject text;
	//сама зброя
	private int text_count = 10;
	void Awake ()
	{
		for(int i=0; i < text_count;i++)
		{
			GameObject temp = (GameObject)Instantiate(text);
			temp.transform.SetParent(transform);
			temp.transform.localScale = temp.transform.localScale / 40.0f;
			temp.SetActive(false);
			text_list.Add(temp);
//			Debug.Log("Text Added");
		}

	}
	
	public void LaunchText(GameObject Caller,int dmg,bool crit)
	{
		if(text_list != null);
		{
			for(int i = 0;i < text_count;i++)
			{
				/*тут перевіряєм чи обєкт не є активний
				 * якшо неактивний берем його
				 * в іншому разі рухаємось далі */
				if(!text_list[i].activeInHierarchy)
				{
					text_list[i].SetActive(true);
					text_list[i].transform.position = Caller.transform.position;
					text_list[i].GetComponent<Dmg_Text_Script>().TurnOn(dmg);
					if(crit)
						text_list[i].GetComponent<Dmg_Text_Script>().Crit();
					break;
				}
			}
		}
	}

}
