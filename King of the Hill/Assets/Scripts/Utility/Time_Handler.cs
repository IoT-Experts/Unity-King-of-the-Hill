using UnityEngine;
using System.Collections;

public class Time_Handler : MonoBehaviour {
	//public string time_str;
	public int time;
	//public int minutes;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Time");
	}
	IEnumerator Time ()
	{
		while(true)
		{
			yield return new WaitForSeconds(1.0f);
			time++;
		}
	}
	public string ReturnTime ()
	{
		string str = "";
		str += (time/60).ToString();
		str += " : ";
		if((time%60) < 10)
		{
			str += "0";
		}
		str += (time%60).ToString();
		return str;
	}
	public int ReturnMinutes ()
	{
		int temp;
		temp = time/60;
		return temp;
	}
}
