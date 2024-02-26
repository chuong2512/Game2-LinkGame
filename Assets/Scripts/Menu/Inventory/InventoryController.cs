using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    public static InventoryController instance;
    public InventoryAvatarEntry activeAvatar;
    public InventoryItemEntry activeItem;

    public InventoryAvatarLoader avatarLoader;
    public InventoryItemLoader itemLoader;

    public System.Action onCloseAction;

    void Awake()
    {
        instance = this;
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
    }

    public void ActiveAvatar(Avatar avatar)
    {
        activeAvatar.LoadAvatar(avatar);
    }

    public void ActiveItem(Item item)
    {
        activeItem.LoadItem(item);
    }

}
