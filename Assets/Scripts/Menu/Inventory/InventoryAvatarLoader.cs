using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryAvatarLoader : MonoBehaviour
{

    List<int> purchasedAvatarsId;
    public Transform avatarsContainer;
    public GameObject avatarPrefab;

    public Avatars avatars;

    void Start()
    {
        LoadPurchasedAvatars();
    }

    //Load cac avatar da mua
    void LoadPurchasedAvatars()
    {
        foreach (int avatarId in Attributes.GetPurchasedAvatarsId())
        {
            AddAvatar(avatars.GetAvatarById(avatarId));
        }
        InventoryController.instance.ActiveAvatar(avatars.GetAvatarById(Attributes.selectedAvatar));
    }

    public void AddAvatar(Avatar avatar)
    {
        GameObject entry = Instantiate(avatarPrefab) as GameObject;
        entry.GetComponent<InventoryAvatarEntry>().LoadAvatar(avatar);
        entry.transform.SetParent(avatarsContainer);
        entry.transform.localScale = new Vector3(1, 1, 1);
    }
}
