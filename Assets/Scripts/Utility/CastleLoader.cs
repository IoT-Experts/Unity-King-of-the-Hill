using UnityEngine;
using System.Collections;

public class CastleLoader : MonoBehaviour {
	public SpriteRenderer me;
	public string path;
	// Use this for initialization
	void Start ()
	{
		me.sprite = Resources.Load<Sprite>(path);  
	}
}
