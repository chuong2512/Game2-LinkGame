using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SocialMenu : MonoBehaviour
{
    public GameObject topTab;
    public GameObject friendsTab;
    public GameObject discussionTab;
    
    public void Open()
    {
        OpenTop();
        gameObject.SetActive(true);
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Play()
    {
        LoadingScreen.Load(Scenes.GAME_PLAY);
    }

    public void OpenTop()
    {
        DisableAllTabs();
        topTab.SetActive(true);
    }

    public void OpenFriends()
    {
        DisableAllTabs();
        friendsTab.SetActive(true);
    }

    public void OpenDiscussion()
    {
        DisableAllTabs();
        discussionTab.SetActive(true);
    }

    void DisableAllTabs()
    {
        topTab.SetActive(false);
        friendsTab.SetActive(false);
        discussionTab.SetActive(false);
    }
}
