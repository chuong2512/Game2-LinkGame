using UnityEngine;
using System.Collections;

public class ComingSoonController : MonoBehaviour {

	public System.Action onCloseAction;

	public void Open()
	{
		gameObject.SetActive(true);
		if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
	}

	public void Close()
	{
		gameObject.SetActive(false);
		if (onCloseAction != null) onCloseAction();
		if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
	}
}
