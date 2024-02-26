using UnityEngine;
using System.Collections;

public class GameIntro : MonoBehaviour
{

    public bool isPic2 = false;
    public bool isPic3 = false;
    public bool isPic4 = false;
    public bool isPic5 = false;
    public Animator anim;
    private int i = 2;

    public GameObject blackScreen;

    void Start()
    {
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.STORY);
		if (!Attributes.IsPlayed())
        {
            Skip();
        }
        else
        {
            Attributes.SetPlayed();
            blackScreen.SetActive(false);
        }
    }

    public void PressedButton()
    {
        switch (i)
        {
            case 2:
                isPic2 = true;
                i = 3;
                break;
            case 3:
                isPic3 = true;
                isPic2 = false;
                i = 4;
                break;
            case 4:
                isPic4 = true;
                isPic3 = false;
                i = 5;
                break;
            case 5:
                isPic5 = true;
                isPic4 = false;
                i = 6;
                break;
            case 6:
                LoadingScreen.Load(Scenes.LOGIN);
                break;
        }
        anim.SetBool("isPic2", isPic2);
        anim.SetBool("isPic3", isPic3);
        anim.SetBool("isPic4", isPic4);
        anim.SetBool("isPic5", isPic5);
    }


    public void Skip()
    {
        LoadingScreen.Load(Scenes.MAIN_MENU);
    }
}
