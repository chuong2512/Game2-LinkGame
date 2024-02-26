using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AvatarController : MonoBehaviour
{
    public Avatars avatars;
    public Transform avatarsContainer;
    public GameObject avatarItem;

    void Start()
    {
        if (avatars != null)
        {
            for (int i = 0; i < avatars.avatars.Length - 1; i++)
            {
                GameObject item = Instantiate(avatarItem) as GameObject;
                item.GetComponent<ShopAvatarEntry>().LoadAvatar(avatars.avatars[i]);
                item.transform.SetParent(avatarsContainer);
                item.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
