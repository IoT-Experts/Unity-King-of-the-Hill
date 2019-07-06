using UnityEngine;
using System.Collections;

public class GameScene_background : MonoBehaviour {
	//public GameObject[] seasons;
	GameObject background;
	// Use this for initialization
	void Start ()
	{
		Choose_Background();

	}

	void Choose_Background ()
	{
		int i;
		i = Random.Range(0,5);	
		if(i < 2)
		{
			background = Instantiate(Resources.Load("Prefabs/Backgrounds/Autumn")) as GameObject;
		}
		if((i >=2) &(i < 4))
		{
			background = Instantiate(Resources.Load("Prefabs/Backgrounds/Summer")) as GameObject;
		}
		if(i == 4)
		{
				background = Instantiate(Resources.Load("Prefabs/Backgrounds/Winter")) as GameObject;
		}
	}

	

}
