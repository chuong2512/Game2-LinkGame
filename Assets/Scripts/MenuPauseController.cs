using UnityEngine;
using System.Collections;

public class MenuPauseController : MonoBehaviour {

	// Use this for initialization
	public void Quit() {
		Application.Quit ();
	}

	public void Continue() {
		gameObject.SetActive (false);
	}
}
