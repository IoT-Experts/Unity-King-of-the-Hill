using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
	

}
