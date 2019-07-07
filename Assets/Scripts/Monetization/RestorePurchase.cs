using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using System;
public class RestorePurchase : MonoBehaviour {
	public AudioClip music;
	public AudioClip music2;
	public Shop_Canvas shop_scr;
	public bool save = false;
	// Use this for initialization
	void Awake () 
	{

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			.EnableSavedGames()
			.Build();
		PlayGamesPlatform.InitializeInstance(config);

		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;

		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();

		

	}

	public void Restore (int n)
	{
		if(n == 0)
		{
			save = true;
		}
		else
		{
			save = false;
		}
		if(!Social.localUser.authenticated)
		{
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					ShowSelectUI();
					Debug.Log ("Login Sucess");
				} else {
					Debug.Log ("Login failed");
				}
			});
		}
		else
		{
			ShowSelectUI();
		}
	}

	void ShowSelectUI ()
	{

		uint maxNumToDisplay = 5;
		bool allowCreateNew = true;
		bool allowDelete = true;

		ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
		savedGameClient.ShowSelectSavedGameUI("Select saved game",
			maxNumToDisplay,
			allowCreateNew,
			allowDelete,
			OnSavedGameSelected);
	}
	public void OnSavedGameSelected (SelectUIStatus status, ISavedGameMetadata game) {
		if (status == SelectUIStatus.SavedGameSelected) {
			OpenSavedGame("NewGame");
			// handle selected game save
		} else {
			// handle cancel or error
		}
	}
	void OpenSavedGame(string filename)
	{
		ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

		savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork,
			ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
	}

	public void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game) {
		if (status == SavedGameRequestStatus.Success) {
			
			int diam = PlayerPrefs.GetInt("Diamonds");

			int[] sv = new int[64];
			sv[0] = PlayerPrefs.GetInt("Diamonds");
			if(PlayerPrefs.GetString("Doubler") == "Have") 
				sv[1] = 1;
			else
				sv[1] = 0;
			sv[2] = PlayerPrefs.GetInt("olaf_power");
			sv[3] = PlayerPrefs.GetInt("olaf_stam");
			sv[4] = PlayerPrefs.GetInt("olaf_stam_regen");
			sv[5] = PlayerPrefs.GetInt("olaf_castle");
			sv[6] = PlayerPrefs.GetInt("olaf_crit_chance");
			sv[7] = PlayerPrefs.GetInt("olaf_crit_power");
			sv[8] = PlayerPrefs.GetInt("olaf_weapon");
			if(PlayerPrefs.GetString("OdiCheck") == "Open")
				sv[9] = 1;
			else
				sv[9] = 0;
			sv[10] = PlayerPrefs.GetInt("odi_power");
			sv[11] = PlayerPrefs.GetInt("odi_stam");
			sv[12] = PlayerPrefs.GetInt("odi_stam_regen");
			sv[13] = PlayerPrefs.GetInt("odi_castle");
			sv[14] = PlayerPrefs.GetInt("odi_crit_chance");
			sv[15] = PlayerPrefs.GetInt("odi_crit_power");
			sv[16] = PlayerPrefs.GetInt("odi_weapon");
			if(PlayerPrefs.GetString("FionaCheck") == "Open")
				sv[17] = 1;
			else
				sv[17] = 0;
			sv[18] = PlayerPrefs.GetInt("fiona_power");
			sv[19] = PlayerPrefs.GetInt("fiona_stam");
			sv[20] = PlayerPrefs.GetInt("fiona_stam_regen");
			sv[21] = PlayerPrefs.GetInt("fiona_castle");
			sv[22] = PlayerPrefs.GetInt("fiona_crit_chance");
			sv[23] = PlayerPrefs.GetInt("fiona_crit_power");
			sv[24] = PlayerPrefs.GetInt("fiona_weapon");
			if(PlayerPrefs.GetString("MorganaCheck") == "Open")
				sv[25] = 1;
			else
				sv[25] = 0;
			sv[26] = PlayerPrefs.GetInt("morgana_power");
			sv[27] = PlayerPrefs.GetInt("morgana_stam");
			sv[28] = PlayerPrefs.GetInt("morgana_stam_regen");
			sv[29] = PlayerPrefs.GetInt("morgana_castle");
			sv[30] = PlayerPrefs.GetInt("morgana_crit_chance");
			sv[31] = PlayerPrefs.GetInt("morgana_crit_power");
			sv[32] = PlayerPrefs.GetInt("morgana_weapon");
			if(PlayerPrefs.GetString("MaximusCheck") == "Open")
				sv[33] = 1;
			else
				sv[33] = 0;
			sv[34] = PlayerPrefs.GetInt("maximus_power");
			sv[35] = PlayerPrefs.GetInt("maximus_stam");
			sv[36] = PlayerPrefs.GetInt("maximus_stam_regen");
			sv[37] = PlayerPrefs.GetInt("maximus_castle");
			sv[38] = PlayerPrefs.GetInt("maximus_crit_chance");
			sv[39] = PlayerPrefs.GetInt("maximus_crit_power");
			sv[40] = PlayerPrefs.GetInt("maximus_weapon");
			if(PlayerPrefs.GetString("BOOM-BOOMCheck") == "Open")
				sv[41] = 1;
			else
				sv[41] = 0;
			sv[42] = PlayerPrefs.GetInt("boom-boom_power");
			sv[43] = PlayerPrefs.GetInt("boom-boom_stam");
			sv[44] = PlayerPrefs.GetInt("boom-boom_stam_regen");
			sv[45] = PlayerPrefs.GetInt("boom-boom_castle");
			sv[46] = PlayerPrefs.GetInt("boom-boom_crit_chance");
			sv[47] = PlayerPrefs.GetInt("boom-boom_crit_power");
			sv[48] = PlayerPrefs.GetInt("boom-boom_weapon");

			byte[] data = new byte[sv.Length * 4];
			for (int i = 0; i < sv.Length; i++)
				Array.Copy(BitConverter.GetBytes(sv[i]), 0, data, i * 4, 4);
			

			TimeSpan tim = new TimeSpan (0, 0, (int)Time.realtimeSinceStartup);
			//byte[] coins = System.BitConverter.GetBytes(diam);
			if(save)
			{
				SaveGame(game,data,tim);
			}
			else
			{
				LoadGameData(game);
			}
			// handle reading or writing of saved game.
		} else {
			// handle error
			Debug.Log("Saved data opened ");

		}
	}

	void SaveGame (ISavedGameMetadata game, byte[] savedData, TimeSpan totalPlaytime) {
		
		ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

		SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
		builder = builder
			.WithUpdatedPlayedTime(totalPlaytime)
			.WithUpdatedDescription("Saved game at " + DateTime.Now);
		//if (savedImage != null) {
			// This assumes that savedImage is an instance of Texture2D
			// and that you have already called a function equivalent to
			// getScreenshot() to set savedImage
			// NOTE: see sample definition of getScreenshot() method below
		//	byte[] pngData = null;
		//	builder = builder.WithUpdatedPngCoverImage(pngData);
		//}
		SavedGameMetadataUpdate updatedMetadata = builder.Build();
		savedGameClient.CommitUpdate(game, updatedMetadata, savedData, OnSavedGameWritten);
	}

	public void OnSavedGameWritten (SavedGameRequestStatus status, ISavedGameMetadata game) {
		if (status == SavedGameRequestStatus.Success) {
			
			// handle reading or writing of saved game.
			} else {
			// handle error
			}
		}
	void LoadGameData (ISavedGameMetadata game) {
		ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
		savedGameClient.ReadBinaryData(game, OnSavedGameDataRead);
	}

	public void OnSavedGameDataRead (SavedGameRequestStatus status, byte[] data) {
		if (status == SavedGameRequestStatus.Success) {
			int diam;
			int[] sv = new int[data.Length / 4];
			for (int i = 0; i < data.Length; i += 4)
				sv[i / 4] = BitConverter.ToInt32(data, i);
			diam = sv[0];
			PlayerPrefs.SetInt("Diamonds",sv[0]);
			if(sv[1] == 1) 
				PlayerPrefs.SetString("Doubler","Have");
			else
				PlayerPrefs.SetString("Doubler","nope");

			PlayerPrefs.SetInt("olaf_power",sv[2]);
			PlayerPrefs.SetInt("olaf_stam",sv[3]);
			PlayerPrefs.SetInt("olaf_stam_regen",sv[4]);
			PlayerPrefs.SetInt("olaf_castle",sv[5]);
			PlayerPrefs.SetInt("olaf_crit_chance",sv[6]);
			PlayerPrefs.SetInt("olaf_crit_power",sv[7]);
			PlayerPrefs.SetInt("olaf_weapon",sv[8]);
			if(sv[9] == 1)
				PlayerPrefs.SetString("OdiCheck","Open");
			else
				PlayerPrefs.SetString("OdiCheck","nope");
			
			PlayerPrefs.SetInt("odi_power",sv[10]);
			PlayerPrefs.SetInt("odi_stam",sv[11]);
			PlayerPrefs.SetInt("odi_stam_regen",sv[12]);
			PlayerPrefs.SetInt("odi_castle",sv[13]);
			PlayerPrefs.SetInt("odi_crit_chance",sv[14]);
			PlayerPrefs.SetInt("odi_crit_power",sv[15]);
			PlayerPrefs.SetInt("odi_weapon",sv[16]);

			if(sv[17] == 1)
				PlayerPrefs.SetString("FionaCheck","Open");
			else
				PlayerPrefs.SetString("FionaCheck","nope");

			PlayerPrefs.SetInt("fiona_power",sv[18]);
			PlayerPrefs.SetInt("fiona_stam",sv[19]);
			PlayerPrefs.SetInt("fiona_stam_regen",sv[20]);
			PlayerPrefs.SetInt("fiona_castle",sv[21]);
			PlayerPrefs.SetInt("fiona_crit_chance",sv[22]);
			PlayerPrefs.SetInt("fiona_crit_power",sv[23]);
			PlayerPrefs.SetInt("fiona_weapon",sv[24]);

			if(sv[25] == 1)
				PlayerPrefs.SetString("MorganaCheck","Open");
			else
				PlayerPrefs.SetString("MorganaCheck","nope");

			PlayerPrefs.SetInt("morgana_power",sv[26]);
			PlayerPrefs.SetInt("morgana_stam",sv[27]);
			PlayerPrefs.SetInt("morgana_stam_regen",sv[28]);
			PlayerPrefs.SetInt("morgana_castle",sv[29]);
			PlayerPrefs.SetInt("morgana_crit_chance",sv[30]);
			PlayerPrefs.SetInt("morgana_crit_power",sv[31]);
			PlayerPrefs.SetInt("morgana_weapon",sv[32]);

			if(sv[33] == 1)
				PlayerPrefs.SetString("MaximusCheck","Open");
			else
				PlayerPrefs.SetString("MaximusCheck","nope");

			PlayerPrefs.SetInt("maximus_power",sv[34]);
			PlayerPrefs.SetInt("maximus_stam",sv[35]);
			PlayerPrefs.SetInt("maximus_stam_regen",sv[36]);
			PlayerPrefs.SetInt("maximus_castle",sv[37]);
			PlayerPrefs.SetInt("maximus_crit_chance",sv[38]);
			PlayerPrefs.SetInt("maximus_crit_power",sv[39]);
			PlayerPrefs.SetInt("maximus_weapon",sv[40]);

			if(sv[41] == 1)
				PlayerPrefs.SetString("BOOM-BOOMCheck","Open");
			else
				PlayerPrefs.SetString("BOOM-BOOMCheck","nope");

			PlayerPrefs.SetInt("boom-boom_power",sv[42]);
			PlayerPrefs.SetInt("boom-boom_stam",sv[43]);
			PlayerPrefs.SetInt("boom-boom_stam_regen",sv[44]);
			PlayerPrefs.SetInt("boom-boom_castle",sv[45]);
			PlayerPrefs.SetInt("boom-boom_crit_chance",sv[46]);
			PlayerPrefs.SetInt("boom-boom_crit_power",sv[47]);
			PlayerPrefs.SetInt("boom-boom_weapon",sv[48]);
		
			shop_scr.ChangeDiamText();
		} else {
			// handle error
		}
	}






}
