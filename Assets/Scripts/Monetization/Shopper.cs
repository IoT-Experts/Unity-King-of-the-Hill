using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Shopper : MonoBehaviour,IStoreListener {

	private static IStoreController m_StoreController;                                                                  // Reference to the Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; 

	public Button doubler_button;
	public AudioClip button_sound;
	public AudioClip button_back_sound;
	public Shop_Canvas shop_scr;

	public Text price;
	// Product identifiers for all products capable of being purchased: "convenience" general identifiers for use with Purchasing, and their store-specific identifier counterparts 
	// for use with and outside of Unity Purchasing. Define store-specific identifiers also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

	// set up your id here
	private static string DoublerID = "double_diamonds";
	private static string CupID = "cup_diamonds";
	private static string HornID = "horn_diamonds";
	private static string BarrelID = "barrel_diamonds";
	private static string ChestID = "chest_diamonds";
	private static string MountainID = "mountain_diamonds";
	private static string NewProductID = "new_id";





	void Start()
	{
		// If we haven't set up the Unity Purchasing reference
		if (m_StoreController == null)
		{
			// Begin to configure our connection to Purchasing
			InitializePurchasing();
		}
	}
		//InitializePurchasing();

	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}

		// Create a builder, first passing in a suite of Unity provided stores.
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

		builder.Configure<IGooglePlayConfiguration>().SetPublicKey("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAsu5dLoXy2bkJzG0fJJYX0bLyAdNinSzQLisJz/1gEkQF1Q6u7pNUL4tkXDztjZkvAwvtD1+2GSCz0TvYGoGDcXehd6xc8bFICdIHgSON8QcsZnOCR7O3lLv38J5Qc8bLRAXDWJcdBGKU2MVBto1KCKFmOEjmPzsWzk6KtRnEpOfOJVstuvJOd0jdIbXVjyrI+qR2HW3XWtjXIowQfuQ58XvO7i8Ral0VRnE7YBvNOUPhUpRaOCqVeeaQh/RSmtqE8gzyi4CCPAuUWW27K1qxq+KtBjay28l4QB+ORjVpzxSu0+MknJ+1K/L9ZWr5p9c8mdrZanIDFKYh1AsenDM64wIDAQAB");
		// Add a product to sell / restore by way of its identifier, associating the general identifier with its store-specific identifiers.
		//builder.AddProduct(CupID, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable,       AppleAppStore.Name },{ kProductNameGooglePlayConsumable,  GooglePlay.Name },});

		builder.AddProduct(CupID,ProductType.Consumable);
		builder.AddProduct(DoublerID,ProductType.Consumable);
		builder.AddProduct(BarrelID,ProductType.Consumable);
		builder.AddProduct(HornID,ProductType.Consumable);
		builder.AddProduct(MountainID,ProductType.Consumable);
		builder.AddProduct(ChestID,ProductType.Consumable);
		builder.AddProduct(NewProductID,ProductType.Consumable);

		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}
	public bool Init ()
	{
		return IsInitialized();
	}

	public string CheckPrices (string id)
	{
		if(m_StoreController != null)
		{
		Product product = m_StoreController.products.WithID(id);
		return product.metadata.localizedPriceString;
		} else
		{
			return "";
		}
			
	}
		

	public void BuyDoubler ()
	{
		MusicManager.instance.PlayMusic(button_back_sound);
		Debug.Log("Button pressed");
		BuyProductID(DoublerID);
	}
	public void BuyCupOfDiamonds ()
	{
		MusicManager.instance.PlayMusic(button_back_sound);
		BuyProductID(CupID);
	}

	public void BuyHornOfDiamonds ()
	{
		MusicManager.instance.PlayMusic(button_back_sound);
		BuyProductID(HornID);
	}
	public void BuyBarrelOfDiamonds ()
	{
		MusicManager.instance.PlayMusic(button_back_sound);
		BuyProductID(BarrelID);
	}
	public void BuyChestOfDiamonds ()
	{
		MusicManager.instance.PlayMusic(button_back_sound);
		BuyProductID(ChestID);
	}
	public void BuyMountainOfDiamonds ()
	{
		MusicManager.instance.PlayMusic(button_back_sound);
		BuyProductID(MountainID);
	}
	public void BuyNewProduct ()
	{
		MusicManager.instance.PlayMusic(button_back_sound);
		BuyProductID(NewProductID);
	}


	void BuyProductID(string productId)
	{
		// If the stores throw an unexpected exception, use try..catch to protect my logic here.
		try
		{
			// If Purchasing has been initialized ...
			if (IsInitialized())
			{
				// ... look up the Product reference with the general product identifier and the Purchasing system's products collection.
				Product product = m_StoreController.products.WithID(productId);

				// If the look up found a product for this device's store and that product is ready to be sold ... 
				if (product != null && product.availableToPurchase)
				{
					Debug.Log (string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
					m_StoreController.InitiatePurchase(product);
				}
				// Otherwise ...
				else
				{
					// ... report the product look-up failure situation  
					Debug.Log ("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
				}
			}
			// Otherwise ...
			else
			{
				// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or retrying initiailization.
				Debug.Log("BuyProductID FAIL. Not initialized.");
				InitializePurchasing();
			}
		}
		// Complete the unexpected exception handling ...
		catch (Exception e)
		{
			// ... by reporting any unexpected exception for later diagnosis.
			Debug.Log ("BuyProductID: FAIL. Exception during purchase. " + e);
		}
	}


	// Restore purchases previously made by this customer. Some platforms automatically restore purchases. Apple currently requires explicit purchase restoration for IAP.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}

		// If we are running on an Apple device ... 
		if (Application.platform == RuntimePlatform.IPhonePlayer || 
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");

			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. Expect a confirmation response in the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}


	//  
	// --- IStoreListener
	//

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
		// Purchasing has succeeded initializing. Collect our Purchasing references.
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
	}


	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, DoublerID, StringComparison.Ordinal))
		{
			PlayerPrefs.SetString("Doubler","Have");
			MusicManager.instance.PlayMusic(button_sound);
		}
		if (String.Equals(args.purchasedProduct.definition.id, CupID, StringComparison.Ordinal))
		{
			int dia = PlayerPrefs.GetInt("Diamonds");
			dia += 1000;
			PlayerPrefs.SetInt("Diamonds",dia);
			MusicManager.instance.PlayMusic(button_sound);
			shop_scr.ChangeDiamText();
		}
		if (String.Equals(args.purchasedProduct.definition.id, HornID, StringComparison.Ordinal))
		{
			int dia = PlayerPrefs.GetInt("Diamonds");
			dia += 5000;
			PlayerPrefs.SetInt("Diamonds",dia);
			MusicManager.instance.PlayMusic(button_sound);
			shop_scr.ChangeDiamText();
		}
		if (String.Equals(args.purchasedProduct.definition.id, BarrelID, StringComparison.Ordinal))
		{
			int dia = PlayerPrefs.GetInt("Diamonds");
			dia += 10000;
			PlayerPrefs.SetInt("Diamonds",dia);
			MusicManager.instance.PlayMusic(button_sound);
			shop_scr.ChangeDiamText();
		}
		if (String.Equals(args.purchasedProduct.definition.id, ChestID, StringComparison.Ordinal))
		{
			int dia = PlayerPrefs.GetInt("Diamonds");
			dia += 50000;
			PlayerPrefs.SetInt("Diamonds",dia);
			MusicManager.instance.PlayMusic(button_sound);
			shop_scr.ChangeDiamText();
		}
		if (String.Equals(args.purchasedProduct.definition.id, MountainID, StringComparison.Ordinal))
		{
			int dia = PlayerPrefs.GetInt("Diamonds");
			dia += 100000;
			PlayerPrefs.SetInt("Diamonds",dia);
			MusicManager.instance.PlayMusic(button_sound);
			shop_scr.ChangeDiamText();
		}
		if(String.Equals(args.purchasedProduct.definition.id,NewProductID,StringComparison.Ordinal))
		
		{
			// if your buy your new product give it to him
			// smth like diamonds += 1000000 or new hero, depent on your new product 
			// write it HERE!!
		}
		// Or ... a non-consumable product has been purchased by this user.

		else 
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));}// Return a flag indicating wither this product has completely been received, or if the application needs to be reminded of this purchase at next app launch. Is useful when saving purchased products to the cloud, and when that save is delayed.
		return PurchaseProcessingResult.Complete;
	}


	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing this reason with the user.

	}
}