using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour {

	public BackGroundPopup NightBackGround;
	public BackGroundPopup DayBackGround;
	public BackGroundPopup ResultBackGround;
	public GameObject boardGame;

	int randomBackGround = 0;

	void Start () {
		ViewBackGround ();
	}
	
	private void ViewBackGround()
	{
		int hour = System.DateTime.Now.Hour;
		if (hour > 6 && hour < 19) {
			DayBackGround.Open ();
			NightBackGround.Close ();
		} else {
			DayBackGround.Close();
			NightBackGround.Open();
		}
	}
	
	public void ViewResultBackGround()
	{
		boardGame.SetActive(false);
		DayBackGround.Close ();
		NightBackGround.Close ();
		ResultBackGround.Open();
	}
}
