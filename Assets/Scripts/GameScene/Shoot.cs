using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
	public WeaponPoolManager weapon_system;
	public GameObject weapon;

	public AudioClip exhaust_sound;
	public AudioClip shoot_sound;

	public Animator myAnim;

	public Transform weaponPosition;
	public bool exhausted = false;
	private bool start_exhaust_animation = false;
	private float stamina;
	private float stRegen;
	private float maxStamina;

	private float  shootCost = 23; //завжди має так бути

	public Slider stSlider;
	public Image fill;
	public GameObject tempFill;

	public static bool anim_play;
	void Shot()
	{
		if((stamina > shootCost)&(!exhausted))
		{
			myAnim.SetTrigger("Shoot");
			//Invoke("Shooting",0.0f);
		} else 
		{
			if(!exhausted)
			{
				myAnim.SetTrigger("Shoot");
				stamina = 0;
				start_exhaust_animation = true;
				//Shooting();
			}

		}
	}

	public void Shooting ()
	{
		weapon_system.LaunchWapon(gameObject,weaponPosition);
		MusicManager.instance.PlayMusic(shoot_sound);
		stSlider.value = stamina;
		if(start_exhaust_animation)
		{
			start_exhaust_animation = false;
			Exhausted();
		} else
		{
			stamina -= shootCost;
		}
		stSlider.value = stamina;
	}
	public void RecoverFunc ()
	{
		exhausted = false;
		EventManager.instance.exhausted = false;
	}

	void Exhausted ()
	{
		myAnim.SetTrigger("Exhausted");
		MusicManager.instance.PlayExhaust(exhaust_sound);
		EventManager.instance.exhausted = true;
		stRegen /= 1.8f;
		exhausted = true;
		fill.color = Color.red;
		Invoke("Recover",3.0f);

	}
	void Recover ()
	{
		MusicManager.instance.Stop_Exhaust();
		stRegen *= 1.8f;
		exhausted = false;
		EventManager.instance.exhausted = false;
		fill.color = Color.green;
		myAnim.SetTrigger("Recovered");
	}

	void PreShoot ()
	{
		
		myAnim.SetTrigger("PreShoot");
	}

	void NotShoot ()
	{
		myAnim.SetTrigger("NotShooted");
	}

	void onLevelWasLoaded()
	{
		myAnim = null;
	}
	void onDestroy ()
	{
		myAnim = null;
		EventManager.swipe -= Shot;
		EventManager.touchbeg -= PreShoot;
		EventManager.notswipe -= NotShoot;
	
	}
	public void clear ()
	{
		EventManager.swipe -= Shot;
		EventManager.touchbeg -= PreShoot;
		EventManager.notswipe -= NotShoot;
	}
	void onEnable ()
	{
		
		if(myAnim = null)
		{
			myAnim = gameObject.GetComponent<Animator>();
		}

	}
	// Use this for initialization
	void Start () 
	{
		stRegen = Data.instance.st_regen;
		maxStamina = Data.instance.max_stamina;

		stSlider = Slider.FindObjectOfType<Slider>();
		tempFill = GameObject.Find("Fill");
		fill = tempFill.GetComponent<Image>();
		anim_play = false;

		stamina = maxStamina;
		stSlider.maxValue = maxStamina;
		stSlider.value = stamina;

		EventManager.swipe +=Shot;
		EventManager.touchbeg +=PreShoot;
		EventManager.notswipe +=NotShoot;
		myAnim = null;
		myAnim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()  {

		if(myAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			anim_play = false;
		} else
		{
			anim_play = true;
		}
	if(stamina < maxStamina)
		{
			stamina += Time.deltaTime * stRegen;
			if(stamina > maxStamina) stamina = maxStamina;
			stSlider.value = stamina;
		}
}
}