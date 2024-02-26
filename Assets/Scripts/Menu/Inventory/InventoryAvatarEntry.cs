using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InventoryAvatarEntry : MonoBehaviour
{
    public Image avatarImage;

    Avatar avatar;

    public void LoadAvatar(Avatar avatar)
    {
        avatarImage.sprite = avatar.sprite;
        this.avatar = avatar;
    }

    public void ActiveAvatar()
    {
        InventoryController.instance.ActiveAvatar(avatar);
        Attributes.ActiveAvatar(avatar.id);
		Debug.Log ("Active avatar: " + avatar.id);
    }
}
