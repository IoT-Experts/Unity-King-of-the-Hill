using UnityEngine;
using System.Collections;

public class ScreenGate : MonoBehaviour {
	public LoadScreen scr;
	//AnimationState
	// Use this for initialization
	public void GateOpen ()
	{
		scr.GateOpen();
	}
}
