using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour {

	public static PopupController instance;

	public GameObject loadScreenPopup;
	public GameObject storyPopup;
	public GameObject loginPopup;
	public GameObject menuPopup;
	public GameObject settingPopup;
	public GameObject iventoryPopup;
	public GameObject shopPopup;
	public GameObject gamePlayPopup;

	public void ActiveLoadScreenPopup()
	{
		SetFalseAllPopup ();
		loadScreenPopup.SetActive (true);
	}

	public void ActiveStorePopup()
	{
		SetFalseAllPopup ();
		storyPopup.SetActive (true);
	}

	public void ActiveLoginPopup()
	{
		SetFalseAllPopup ();
		loginPopup.SetActive (true);
	}

	public void ActiveMenuPopup()
	{
		SetFalseAllPopup ();
		menuPopup.SetActive (true);
	}

	public void ActiveSettingPopup()
	{
		SetFalseAllPopup ();
		settingPopup.SetActive (true);
	}

	public void ActiveIventoryPopup()
	{
		SetFalseAllPopup ();
		menuPopup.SetActive (true);
		iventoryPopup.SetActive (true);
	}

	public void ActiveShopPopup()
	{
		SetFalseAllPopup ();
		menuPopup.SetActive (true);
		shopPopup.SetActive (true);
	}

	public void ActiveGamePlayPopup()
	{
		SetFalseAllPopup ();
		gamePlayPopup.SetActive (true);
	}

	public void ActiveResultPopup()
	{

	}

	public void SetFalseAllPopup(){
		loadScreenPopup.SetActive (false);
		storyPopup.SetActive (false);
		loginPopup.SetActive (false);
		menuPopup.SetActive (false);
		iventoryPopup.SetActive (false);
		shopPopup.SetActive (false);
		gamePlayPopup.SetActive (false);
	}
}
