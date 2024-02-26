using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopItemEntry : MonoBehaviour
{
	public GameObject purcharsedMoney;
    public Image itemImg;
    public Text txtDescription;
    public Text txtGem;

    Item currentItem;

    public Button purchaseButton;

    public void LoadItem(Item item)
    {
        currentItem = item;
        name = item.name;
        txtDescription.text = item.description;
        txtGem.text = item.gem.ToString();
        itemImg.sprite = item.sprite;
		if(Attributes.GetPurchasedItemsId().Contains(item.id)){
			purcharsedMoney.SetActive(false);
		}
    }

    public void Buy()
    {
        if (currentItem.gem > Attributes.GetGem())
        {
            // Xu ly viec khong du tien hoac gem de mua o day
            Debug.Log("Not enough gem");
            return;
        }
        Attributes.AddGem(-currentItem.gem);
        Attributes.PurchaseItem(currentItem.id);
        purchaseButton.interactable = false;
		purcharsedMoney.SetActive (false);
        if (InventoryController.instance != null) InventoryController.instance.itemLoader.AddItem(currentItem);
    }
}
