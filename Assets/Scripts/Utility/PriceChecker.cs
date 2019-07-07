using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PriceChecker : MonoBehaviour {
	public Shopper shop;
	public Text price_text;
	public string id;
	// Use this for initialization
	void OnEnable ()
	{
		CheckPrice();
	}
	void CheckPrice ()
	{
		if(shop.Init())
		{
			if(shop.CheckPrices(id) != "")
				price_text.text = shop.CheckPrices(id);
		}
		else
		{
			StartCoroutine("CheckFewSeconds");
		}
	}

	IEnumerator CheckFewSeconds ()
	{
		yield return new WaitForSeconds(1.0f);
			CheckPrice();
	}
	

}
