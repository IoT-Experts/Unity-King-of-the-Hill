using UnityEngine;
using System.Collections;

public class MenuEventManager : MonoBehaviour {

	public delegate void Swipe();
	public static event Swipe swipe_left;
	public static event Swipe swipe_right;

	public static MenuEventManager instance;

	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float fingerStartTime = 0.0f;
	private float maxSwipeTime = 0.5f;
	private float minSwipeDist = 50.0f;

	void Awake () 
	{
		//Check if instance already exists
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	
	void Update ()
	{
		if(Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			switch (touch.phase)
			{
			case(TouchPhase.Began):
			{
				fingerStartPos = touch.position;
				fingerStartTime = Time.time;
				isSwipe = true;
			}
				break;
				
			case(TouchPhase.Ended):
				float gestureTime = Time.time - fingerStartTime;
				Vector2 direction = touch.position - fingerStartPos;
				if(Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
				{
					if(isSwipe && gestureTime < maxSwipeTime && direction.magnitude > minSwipeDist)
					{
						if( direction.x > 0 )
							swipe_right();
						else swipe_left();
					}
				}
				break;
				
			}
		}
	}
}
