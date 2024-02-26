using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour
{

    public GameObject avatarsTab;
    public GameObject itemsTab;
    
    public System.Action onCloseAction;

    public void Start()
    {
        OpenAvatars();
    }

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

    public void OpenAvatars()
    {
        avatarsTab.SetActive(true);
        itemsTab.SetActive(false);
    }

    public void OpenItems()
    {
        itemsTab.SetActive(true);
        avatarsTab.SetActive(false);
    }
}
