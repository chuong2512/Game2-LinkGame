using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    public SocialMenu social;
    public SettingController settings;
    public InventoryController inventory;
    public ShopController shop;
	public ComingSoonController comingSoon;

    static bool firstTimePlaying = true;

    public GameObject startObject;
    public GameObject exitConfirmDialog;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        settings.onCloseAction = () => { social.Open(); }; // Open social menu when close setting menu
        inventory.onCloseAction = () => { social.Open(); };
        shop.onCloseAction = () => { social.Open(); };
		comingSoon.onCloseAction = () => { social.Open (); };

        OpenSocial();
        if (SoundManager.instance != null) SoundManager.instance.PlayBGM(BGM.MENU_DAY, BGM.MENU_NIGHT);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (startObject.activeSelf)
            {
                exitConfirmDialog.SetActive(true);
            }
            else
            {
                startObject.SetActive(true);
            }
        }
    }

    public void OpenSocial()
    {
        CloseAll();
        social.Open();
    }

    public void OpenInventory()
    {
        CloseAll();
        inventory.Open();
    }

    public void OpenSettings()
    {
        CloseAll();
        settings.Open();
    }

	public void OpenCommingSoom(){
		CloseAll ();
		comingSoon.Open ();
	}

    public void OpenShop()
    {
        CloseAll();
        shop.Open();
    }

    void CloseAll()
    {
        inventory.Close();
        shop.Close();
        settings.Close();
		comingSoon.Close ();
        social.Close(); // social phải close sau cùng
    }

    public void PlayButtonFX()
    {
        SoundManager.instance.PlaySFX(SFX.CLICK_BUTTON);
    }
}
