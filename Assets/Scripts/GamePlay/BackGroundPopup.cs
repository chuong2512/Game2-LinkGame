using UnityEngine;
using System.Collections;

public class BackGroundPopup : MonoBehaviour {

	public void Open()
	{
		gameObject.SetActive (true);
	}
	public void Close()
	{
		gameObject.SetActive (false);
	}
}
