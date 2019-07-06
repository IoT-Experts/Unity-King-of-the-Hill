using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AfterDeathMenu : MonoBehaviour {

	public Text diamond_text,monsters,time_text,current_points,max_points,boss_text;
	private int diamonds_count,monsters_count,boss_count;
	private string time_str,points_str,max_points_str;
	public Time_Handler time_hand;
	// Use this for initialization
	void Start ()
	{
		diamonds_count = Data.instance.diamonds_collected;
		monsters_count = Data.instance.monsters_slayed;
		boss_count = Data.instance.boss_slayed;
		time_str = time_hand.ReturnTime();
		max_points_str = Data.instance.max_points_str;
		points_str = Data.instance.curr_points_str;
		ChangeTexts();
	}

	public void ChangeTexts ()

	{
		diamond_text.text = diamonds_count.ToString();
		monsters.text = monsters_count.ToString();
		boss_text.text = boss_count.ToString();
		time_text.text = time_str;
		current_points.text = points_str;
		max_points.text = max_points_str;
	}
	

}
