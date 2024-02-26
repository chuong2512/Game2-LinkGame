using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController :MonoBehaviour {

    public static ButtonController instance;
	private static bool CheckLoad = true;
    public GameObject avatarPopup;
    public GameObject background;
    public GameObject closePopup;
    public GameObject discussionPopup;
    public GameObject friendPopup;
	public GameObject topPopup;
    public GameObject highscoreResult;
    public GameObject inventoryPopup;
    public GameObject itemPopup;
    public GameObject loadingPopup;
    public GameObject loginPopup;
    public GameObject menuPopup;
    public GameObject settingPopup;
    public GameObject shopPopup;
    public GameObject socialPopup;
    public GameObject storyPopup;
    public GameObject topbar;


    void Awake() {
        instance = this;
    }

    void Start()
    {
		if (loadingPopup && CheckLoad) {
			loadingPopup.SetActive (true);
			CheckLoad = false;
		} else
		{
			menuPopup.SetActive (true);
			background.SetActive(true);
		}
    }
    
	public void GoShop(){
        SetAllPopupFalse();
        background.SetActive(true);
		menuPopup.SetActive (true);
        topbar.SetActive(true);
		shopPopup.SetActive(true);
	}

	public void CloseShop(){
        SetAllPopupFalse();
		shopPopup.SetActive(false);
        menuPopup.SetActive(true);
        background.SetActive(true);
        topbar.SetActive(true);
        socialPopup.SetActive(true);

	}

	public void GoIventory(){
        SetAllPopupFalse();
        background.SetActive(true);
		menuPopup.SetActive(true);
        topbar.SetActive(true);
        inventoryPopup.SetActive(true);
	}

	public void CloseIventory(){
        SetAllPopupFalse();
		inventoryPopup.SetActive(false);
        menuPopup.SetActive(true);
        background.SetActive(true);
        topbar.SetActive(true);
    }

	public void GoAvatar(){
		itemPopup.SetActive (false);
		avatarPopup.SetActive(true);
	}
	public void GoItem(){
		avatarPopup.SetActive(false);
		itemPopup.SetActive(true);
	}
	public void GoTop(){
		friendPopup.SetActive(false);
		discussionPopup.SetActive(false);
		topPopup.SetActive(true);
	}
	public void GoFriend(){
		friendPopup.SetActive(true);
		discussionPopup.SetActive(false);
		topPopup.SetActive(false);
	}
	public void GoDiscussion(){
		friendPopup.SetActive(false);
		discussionPopup.SetActive(true);
		topPopup.SetActive(false);
	}

    public void GoMenu()
    {
        SetAllPopupFalse();
		menuPopup.SetActive(true);
        background.SetActive(true);
        topbar.SetActive(true);
        socialPopup.SetActive(true);
    }

    public void GoSettingPopup()
    {
        SetAllPopupFalse();
        background.SetActive(true);
        topbar.SetActive(true);
        settingPopup.SetActive(true);
		menuPopup.SetActive(true);
    }

    public void CloseSetting()
    {
        SetAllPopupFalse();
		menuPopup.SetActive(true);
        background.SetActive(true);
        topbar.SetActive(true);
        socialPopup.SetActive(true);
    }

    public void Play()
    {
        SetAllPopupFalse();
        //playPopup.SetActive(true);
		Application.LoadLevel (Strings.SCEN_GAMEPLAY);
    }


    public void GoStory()
    {
        SetAllPopupFalse();
        storyPopup.SetActive(true);
    }
	
    public void GoLogin()
    {
        SetAllPopupFalse();
        loginPopup.SetActive(true);
    }

    public void ClosePopup()
    {
        SetAllPopupFalse();
        menuPopup.SetActive(true);
        socialPopup.SetActive(true);
        topbar.SetActive(true);
        background.SetActive(true);
    }
	

    
    public void SetAllPopupFalse()
    {
        shopPopup.SetActive(false);
        inventoryPopup.SetActive(false);
        friendPopup.SetActive(false);
        discussionPopup.SetActive(false);
		menuPopup.SetActive(false);
        //socialPopup.SetActive(false);
        loginPopup.SetActive(false);
        settingPopup.SetActive(false);
        storyPopup.SetActive(false);
        //loadingPopup.SetActive(false);
        topbar.SetActive(false);
        background.SetActive(false);
    }
}
