using UnityEngine;
using System.Collections;

public class PartCollider : MonoBehaviour {
	public Ratbarb ratbi;
	// Use this for initialization

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.tag == "Weapon")
		{
			ratbi.DetailHit();
			coll.gameObject.SetActive(false);

		}
	}
}
