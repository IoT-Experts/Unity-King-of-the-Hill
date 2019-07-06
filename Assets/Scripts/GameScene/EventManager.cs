using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {
	
	public delegate void SwipeAction();
	public delegate void TouchAction();
	public static event SwipeAction swipe;
	public static event SwipeAction notswipe;
	public static event TouchAction touchbeg;
	public static EventManager instance = null;
	public static Vector2 Napram;

	private Vector2 fingerStartPos = Vector2.zero;

	public bool exhausted = false;
	public bool isSwipe = false;
	private float fingerStartTime = 0.0f;
	private float maxSwipeTime = 0.8f;
	private float maxSwipeDist = 200.0f; //500
	private float minSwipeDist = 40.0f;


	//public Text sw;
	// Use this for initialization
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


	// Update is called once per frame
	void Update ()
	{
	
		if(Input.GetKeyDown(KeyCode.C))
		{
			if(!exhausted)
			{
				touchbeg();
				isSwipe = true;
			}
		}
		if(Input.GetKeyUp(KeyCode.C))
		{
			Napram = new Vector2(4,1)*50;
			if(!exhausted)
			{
				swipe();
			}
		}
		if(Input.GetKeyDown(KeyCode.X))
		{
			if(!exhausted)
			{
				touchbeg();
				isSwipe = true;
			}
		}
		if(Input.GetKeyUp(KeyCode.X))
		{
			Napram = new Vector2(1,2) * 100;
			if(!exhausted)
			{
				swipe();
			}
		}
		if(Input.GetKeyDown(KeyCode.Z))
		{
			if(!exhausted)
			{
				touchbeg();
				isSwipe = true;
			}
		}
		if(Input.GetKeyUp(KeyCode.Z))
		{
			if(!exhausted)
			{
				swipe();
			}
			Napram = new Vector2(1,1)*150;
		}
		//*********************
		if((Time.timeScale > 0) && Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			switch (touch.phase)
			{
			case(TouchPhase.Began):
				{
					if(!Shoot.anim_play) //if()
				{
					fingerStartPos = touch.position;
					fingerStartTime = Time.time;
						isSwipe = true;
						if(!exhausted && (fingerStartPos.x < Screen.width *0.9f) && (fingerStartPos.y < Screen.height * 0.9f))
						{
							isSwipe = true;
							touchbeg();
							//sSwipe = true;
						}
						/*else
						{
							notswipe();//немало бути цього елесе
							isSwipe = false;
						} */
				}
				}
				break;

			case(TouchPhase.Ended):
				if(Time.timeScale > 0)
				{
				float gestureTime = Time.time - fingerStartTime;
				Vector2 direction = touch.position - fingerStartPos;
				//sw.text = direction.magnitude.ToString();
				if(direction.magnitude > maxSwipeDist)
				{
					direction = direction/direction.magnitude*maxSwipeDist;
				}

					if(isSwipe && gestureTime < maxSwipeTime && (direction.x >= 0) )
				{
						if(!exhausted && isSwipe)
					{
							if(direction.magnitude > minSwipeDist)
							{
								swipe();
								isSwipe = false;
							}
							else
							{
								/*
								direction = new Vector2(30,200);
								swipe();
								isSwipe = false;*/
								notswipe();
								isSwipe = false;

							} 
						
					}			
					Napram = direction;
				} else
				{
					notswipe();
					isSwipe = false;
				}
				}

				break;
				
			}
		}
	}
	
}
