using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryItemLoader : MonoBehaviour {

    public Items items;
	public Transform itemsContainer;
	public GameObject itemPrefab;
	
	void Start(){
        LoadPurchasedItems();
	}

    void LoadPurchasedItems()
    {
        foreach (int itemId in Attributes.GetPurchasedItemsId())
        {
            AddItem(items.GetItemById(itemId));
        }
        InventoryController.instance.ActiveItem(items.GetItemById(Attributes.selectedItem));
    }
	

    public void AddItem(Item item)
    {
        GameObject itemObject = Instantiate(itemPrefab) as GameObject;
        itemObject.GetComponent<InventoryItemEntry>().LoadItem(item);
        itemObject.transform.SetParent(itemsContainer);
        itemObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
