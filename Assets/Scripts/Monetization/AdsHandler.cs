using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsHandler : MonoBehaviour {
	
	public string game_id_iOS;
	public string game_id_Android;
	string game_id;
	public bool enableTestMode = true;
	public AudioClip back_button;
	public AudioClip buy_button;
	public Shop_Canvas shop_scr;

	//public Button watch_button;


	// Use this for initialization
	void Start ()
	{
		InitializeAds();
	}
	
	void OnEnable ()
	{
		
	}
	public void InitializeAds ()
	{
		#if UNITY_ANDROID
			game_id = game_id_Android;
		#else
			game_id = game_id_iOS;
		#endif
		Advertisement.Initialize(game_id);

	}

	public void CheckAds ()
	{
		//if(!Advertisement.IsReady())
//			watch_button.interactable = false;
	//	else
		//	watch_button.interactable = true;
	}

	public void WatchVideo ()
	{
		MusicManager.instance.PlayMusic(back_button);
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo",options);
	}

	private void HandleShowResult (ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			MusicManager.instance.PlayMusic(buy_button);
			Debug.Log ("Video completed. User rewarded " + 300 + " credits.");
			int diamonds = PlayerPrefs.GetInt("Diamonds");
			Debug.Log(diamonds);
			Debug.Log(PlayerPrefs.GetInt("Diamonds") + "DIA");
			diamonds += 300;
			PlayerPrefs.SetInt("Diamonds",diamonds);
			shop_scr.ChangeDiamText();
			break;
		case ShowResult.Skipped:
			Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
			Debug.LogError ("Video failed to show.");
			break;
		}
	}
}
