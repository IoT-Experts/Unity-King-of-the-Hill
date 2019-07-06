using UnityEngine;
using System.Collections;

public class King_withTreasure : MonoBehaviour {


	
	// Update is called once per frame
	void Update () 
	{
		Vector3 nn = Vector3.right;
		gameObject.transform.position += Time.deltaTime * 1 * nn ;
	}
}
