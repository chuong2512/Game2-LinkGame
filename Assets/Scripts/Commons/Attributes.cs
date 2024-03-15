using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using CGArt.Utils;
using Sirenix.OdinInspector;

public class Attributes : MonoBehaviour
{
	public static int isPlayed = PlayerPrefs.GetInt(Strings.DATA_IS_PLAYED, 0);
	
    public static int selectedAvatar = DataManager.instance.GetInt(Strings.DATA_CURRENT_AVATAR_ID, Strings.DEFAULT_AVATAR);
    public static int selectedItem = DataManager.instance.GetInt(Strings.DATA_CURRENT_ITEM_ID, Strings.DEFAULT_ITEM);
    public static int currentExp = DataManager.instance.GetInt(Strings.DATA_CURRENT_EXP, 0);
    public static int currentLevel = DataManager.instance.GetInt(Strings.DATA_CURRENT_LEVEL, 1);
    public static int currentGold = PlayerPrefs.GetInt(Strings.DATA_GOLD, 0);
    public static int currentGem = PlayerPrefs.GetInt(Strings.DATA_GEM, 0);

    public static int highScore = DataManager.instance.GetInt(Strings.DATA_CURRENT_HIGH_SCORE);

    public static int backgroundMusic = PlayerPrefs.GetInt(Strings.DATA_BACKGROUND_MUSIC, 1);
    public static int effect = PlayerPrefs.GetInt(Strings.DATA_EFFECT, 0);
    public static int vibrate = PlayerPrefs.GetInt(Strings.DATA_VIBRATE, 1);
    public static int notification = PlayerPrefs.GetInt(Strings.DATA_NOTIFICATION, 0);
    
	public static int isLoggedFacebook = PlayerPrefs.GetInt(Strings.DATA_LOGGED_FACEBOOK, 0);

    public const int IS_ON = 1;
    public const int IS_OFF = 0;

	public static void LoadInitData() {
		isPlayed = PlayerPrefs.GetInt(Strings.DATA_IS_PLAYED, 0);
		
		selectedAvatar = DataManager.instance.GetInt(Strings.DATA_CURRENT_AVATAR_ID, Strings.DEFAULT_AVATAR);
		selectedItem = DataManager.instance.GetInt(Strings.DATA_CURRENT_ITEM_ID, Strings.DEFAULT_ITEM);
		currentExp = DataManager.instance.GetInt(Strings.DATA_CURRENT_EXP, 0);
		currentLevel = DataManager.instance.GetInt(Strings.DATA_CURRENT_LEVEL, 1);
		currentGold = PlayerPrefs.GetInt(Strings.DATA_GOLD, 0);
		currentGem = PlayerPrefs.GetInt(Strings.DATA_GEM, 0);
		
		highScore = DataManager.instance.GetInt(Strings.DATA_CURRENT_HIGH_SCORE);
		
		backgroundMusic = PlayerPrefs.GetInt(Strings.DATA_BACKGROUND_MUSIC, 1);
		effect = PlayerPrefs.GetInt(Strings.DATA_EFFECT, 0);
		vibrate = PlayerPrefs.GetInt(Strings.DATA_VIBRATE, 1);
		notification = PlayerPrefs.GetInt(Strings.DATA_NOTIFICATION, 0);
		
		isLoggedFacebook = PlayerPrefs.GetInt(Strings.DATA_LOGGED_FACEBOOK, 0);

		ActiveAvatar(Strings.DEFAULT_AVATAR);
	}

	void Awake() {
		LoadInitData ();
	}

	public static void SetPlayed()
	{
		isPlayed = 1;
		PlayerPrefs.SetInt (Strings.DATA_IS_PLAYED, isPlayed);
	}

	public static bool IsPlayed()
	{
		if (isPlayed == 0)
			return false;
		else
			return true;
	}
	
    public static void AddGold(int amount)
    {
        currentGold += amount;
        PlayerPrefs.SetInt(Strings.DATA_GOLD, currentGold);
    }

	public static int GetGold()
	{
		return currentGold;
	}

    public static void AddGem(int amount)
    {
        currentGem += amount;
        PlayerPrefs.SetInt(Strings.DATA_GEM, currentGem);
    }

	public static int GetGem()
	{
		return currentGem;
	}

    // set current avatar
    public static void ActiveAvatar(int id)
    {
        selectedAvatar = id;
        DataManager.instance.AddInt(Strings.DATA_CURRENT_AVATAR_ID, id);
    }

	public static void DeleteAvatar(int id){
		Debug.Log ("Delete avatar: " + id);
		if (id != Strings.DEFAULT_AVATAR) {
			DataManager.instance.RemoveIntFromList(Strings.DATA_PURCHASED_AVATARS, id);
			ActiveAvatar(Strings.DEFAULT_AVATAR);
			Debug.Log (selectedAvatar);
		}
	}

    public static void ActiveItem(int id)
    {
        selectedItem = id;
        DataManager.instance.AddInt(Strings.DATA_CURRENT_ITEM_ID, id);
    }

	public static void DeleteItem(int id){
		if (id != Strings.DEFAULT_ITEM) {
			DataManager.instance.RemoveIntFromList(Strings.DATA_PURCHASED_ITEMS, id);
			ActiveItem(Strings.DEFAULT_ITEM);
			Debug.Log(selectedItem);
		}
	}

	public static bool IsLogginFacebook(){
		if (isLoggedFacebook == IS_OFF)
			return false;
		return true;
	}

    public static List<int> GetPurchasedAvatarsId()
    {
		return DataManager.instance.GetIntList(Strings.DATA_PURCHASED_AVATARS);
    }

    public static List<int> GetPurchasedItemsId()
    {
		return DataManager.instance.GetIntList(Strings.DATA_PURCHASED_ITEMS);
    }

    public static void PurchaseAvatar(int avatarId)
    {
        DataManager.instance.AddIntToList(Strings.DATA_PURCHASED_AVATARS, avatarId);
    }

    public static void PurchaseItem(int itemId)
    {
        DataManager.instance.AddIntToList(Strings.DATA_PURCHASED_ITEMS, itemId);
    }

    //set current item
    public static bool SetHighScore(int hscore)
    {
        if (hscore < highScore)
            return false;
        highScore = hscore;
        DataManager.instance.AddInt(Strings.DATA_CURRENT_HIGH_SCORE, highScore);
        return true;
    }

    // get current item
    public static int GetHighScore()
    {
        return highScore;
    }

    // Set level up
    public static void SetLevelUp()
    {
        currentLevel += 1;
		DataManager.instance.AddInt(Strings.DATA_CURRENT_LEVEL, currentLevel);
    }

	public static int GetCurrentLevel()
	{
		return currentLevel;
	}

    //set exp
    public static void SetCurrentExp(int exp)
    {
        currentExp = exp;
		DataManager.instance.AddInt(Strings.DATA_CURRENT_EXP, currentExp);
    }

    //Get current exp
    public static int GetCurrentExp()
    {
        return currentExp;
    }

    //Check levelup
    public static bool CheckLevelUp(int totalExp)
    {
	    if (totalExp < TotalExpToLevelUp())
            return false;
        return true;
    }

    //Total exp to level up
    public static int TotalExpToLevelUp()
    {
		int totalExp = (int)(currentLevel * (currentLevel + 1 ) * (currentLevel + 2 ) * (currentLevel + 2) / 50) + 500;
        return totalExp;
    }

    //set on/off background music
    public static void SetBackgroundMusic(int bgm)
    {
        backgroundMusic = bgm;
        PlayerPrefs.SetInt(Strings.DATA_BACKGROUND_MUSIC, backgroundMusic);
    }
    
    //set on/off effect
    public static void SetEffect(int efft)
    {
        effect = efft;
        PlayerPrefs.SetInt(Strings.DATA_EFFECT, effect);
    }

    //set on/off vibrate
    public static void SetVibrate(int vibr)
    {
        vibrate = vibr;
        PlayerPrefs.SetInt(Strings.DATA_VIBRATE, vibrate);
    }

    //set on/off notification
    public static void SetNotification(int notif)
    {
        notification = notif;
        PlayerPrefs.SetInt(Strings.DATA_NOTIFICATION, notification);
    }
}

