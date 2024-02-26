using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShopAvatarEntry : MonoBehaviour
{
	public GameObject purcharsedMoney;
    public GameObject goldButtonObject;
    public GameObject gemButtonObject;
    public Image avatarImg;
    public Text txtDescription;
    public Text txtGold;
    public Text txtGem;
    public Button gemButton;
    public Button goldButton;
    public Avatar currentAvatar;

    void Start()
    {
        CheckActiveMoney();
    }

    /*
	 * LoadAvatar: Load cac avatar ra cua hang shop
	 * Input: Avatar Object
	 * Output: void
	 * 
	*/
    public void LoadAvatar(Avatar avatar)
    {
        currentAvatar = avatar;
        name = avatar.name;
        txtDescription.text = avatar.description;
        if (Attributes.GetPurchasedAvatarsId().Contains(avatar.id))
        {
            gemButton.interactable = false;
            goldButton.interactable = false;
        }
        if (avatar.gold > 0)
        {
            txtGold.text = avatar.gold.ToString();
        }
        /*else
        {
            txtGem.text = avatar.gem.ToString();
        }*/
        avatarImg.sprite = avatar.sprite;
		if(Attributes.GetPurchasedAvatarsId().Contains(avatar.id)){
			purcharsedMoney.SetActive(false);
		}
    }

    public void Buy()
    {
        if (currentAvatar.gold > Attributes.GetGold())
        {
            // Xu ly viec khong du tien hoac gem de mua o day
            Debug.Log("Not enough resouces");
            return;
        }
        Attributes.AddGold(-currentAvatar.gold);
        //Attributes.AddGem(-currentAvatar.gem);
        Attributes.PurchaseAvatar(currentAvatar.id);
        gemButton.interactable = false;
        goldButton.interactable = false;
		purcharsedMoney.SetActive (false);
        if (InventoryController.instance != null) InventoryController.instance.avatarLoader.AddAvatar(currentAvatar);
    }

    //Kiem tra xem Avatar nay thanh toan bang phuong thuc gi
    public void CheckActiveMoney()
    {
        if (currentAvatar.gold > 0)
        {
            goldButtonObject.SetActive(true);
            gemButtonObject.SetActive(false);
        }
        else
        {
            goldButtonObject.SetActive(false);
            gemButtonObject.SetActive(true);
        }
    }
}
