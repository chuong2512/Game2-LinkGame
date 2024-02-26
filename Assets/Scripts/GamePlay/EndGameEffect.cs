using UnityEngine;
using System.Collections;

public class EndGameEffect : MonoBehaviour {

	public void Open()
	{
        GoogleMobileAdControll.AdmobControll.ShowInterstitial();
		gameObject.SetActive (true);
	}

	public void EndAnimation()
	{
		gameObject.SetActive (false);
		GameManager.instance.SetGameState(GameState.RESULT);
	}
}
