using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
	

	public void Open()
	{
		gameObject.SetActive (true);
	}

	public void Continue()
	{
		gameObject.SetActive (false);
		if (Application.loadedLevelName == Scenes.GAME_PLAY)
			GameManager.instance.SetGameState (GameState.PLAYING);
	}

	public void BackMenu()
	{
		gameObject.SetActive (false);
		if (Application.loadedLevelName == Scenes.GAME_PLAY) {
			LoadingScreen.Load (Scenes.MAIN_MENU);
			Attributes.LoadInitData();
			return;
		}
		
		if (Application.loadedLevelName == Scenes.MAIN_MENU) {
			Application.Quit ();
			return;
		}
	}
}
