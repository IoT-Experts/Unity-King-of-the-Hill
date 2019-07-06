using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dmg_Text_Script : MonoBehaviour {

	public Text myText;
	// Use this for initialization
	void Start () 
	{
	
	}

	public void TurnOn (int dmg)
	{
		myText.canvasRenderer.SetAlpha(1.0f);
		myText.text = dmg.ToString();
		StartAnim();
	}

	public void Crit ()
	{
		myText.color = Color.yellow;
	}
	
	public void StartAnim ()
	{
		myText.CrossFadeAlpha(0.0f,1.0f,false);
		StartCoroutine("Movement");
	}
	IEnumerator Movement ()
	{
		float alpha;
		alpha = myText.canvasRenderer.GetAlpha();
		while(alpha != 0.0f)
		{
			transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up*0.03f, 100f * Time.deltaTime);
			yield return null;
			alpha = myText.canvasRenderer.GetAlpha();
		}
		gameObject.SetActive(false);
		myText.color = Color.red;
	}

}

