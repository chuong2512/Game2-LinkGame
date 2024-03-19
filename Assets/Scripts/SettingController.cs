using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public Toggle backgroundMusicToggle;
    public Toggle effectToggle;
    public Toggle vibrateToggle;
    public Toggle notificationToggle;

    public System.Action onCloseAction;

    // Use this for initialization
    void Start()
    {
        CheckStatus();
    }

    public void Open()
    {
        CheckStatus();
        gameObject.SetActive(true);
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        if (onCloseAction != null) onCloseAction();
    }

    //change value background music
    public void ChangeValueBackgroundMusic()
    {
        Attributes.SetBackgroundMusic(backgroundMusicToggle.isOn ? Attributes.IS_ON : Attributes.IS_OFF);
		if (Attributes.backgroundMusic == Attributes.IS_OFF)
			SoundManager.instance.StopAllPlayBGM ();
		else
			SoundManager.instance.PlayBGM (BGM.MENU_DAY, BGM.MENU_NIGHT);
    }

    //change value effect
    public void ChangeValueEffect()
    {
        Attributes.SetEffect(effectToggle.isOn ? Attributes.IS_ON : Attributes.IS_OFF);
		if(Attributes.effect == Attributes.IS_OFF)
			SoundManager.instance.StopAllPlaySFX ();
    }

    //change value vibrate
    public void ChangeValueVibrate()
    {
        Attributes.SetVibrate(vibrateToggle.isOn ? Attributes.IS_ON : Attributes.IS_OFF);
    }

    //change value notification
    public void ChangeValueNotification()
    {
        Attributes.SetNotification(notificationToggle.isOn ? Attributes.IS_ON : Attributes.IS_OFF);
    }

    private void CheckStatus()
    {
        backgroundMusicToggle.isOn = (Attributes.backgroundMusic == Attributes.IS_ON);
        effectToggle.isOn = (Attributes.effect == Attributes.IS_ON);
        vibrateToggle.isOn = (Attributes.vibrate == Attributes.IS_ON);
        notificationToggle.isOn = (Attributes.notification == Attributes.IS_ON);
    }
}