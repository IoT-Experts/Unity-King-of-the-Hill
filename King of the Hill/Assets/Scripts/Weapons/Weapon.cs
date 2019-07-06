using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float[] power_array2 = {10.0f,10.3f,10.7f,11.0f,11.3f,11.7f,12.2f};

	public Rigidbody2D me;
	public float power; 
	public Transform center_mass;
	//private int her_choosen;
	public Vector2 directionShot;
	public AudioClip Hit_Sound;
	// Use this for initialization


	/*public void Start ()
	{
		power_array[0] = 10.0f;
		power_array[1] = 10.5f;
		power_array[2] = 12;
		power_array[3] = 13;
		power_array[4] = 14;
		power_array[5] = 15;
		power_array[6] = 16;
	}
*/
	public virtual void Shoot () 
	{
		//me.AddForceAtPosition(directionShot,center_mass.position);
		me.AddForce(directionShot);
		//me.AddTorque(directionShot.magnitude / heroPower * 1.6f * -1);
	}

	public virtual void TurnOn ()
	{
		directionShot = EventManager.Napram * power;
		Shoot();
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if(!(coll.gameObject.tag == "Enemy")) 
		{
			gameObject.SetActive(false);
		} else
		{
			MusicManager.instance.PlayMusic(Hit_Sound);
		}
	} 
}
