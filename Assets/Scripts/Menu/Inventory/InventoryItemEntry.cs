using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItemEntry : MonoBehaviour
{

    public Image itemImage;
    public static int itemId;
    Item item;
    
    public void LoadItem(Item item)
    {
        itemImage.sprite = item.sprite;
        this.item = item;
    }

    public void ActiveItem()
    {
        InventoryController.instance.ActiveItem(item);
        Attributes.ActiveItem(item.id);
    }
}
