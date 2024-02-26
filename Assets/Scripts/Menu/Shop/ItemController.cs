using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{

    public Items items;
    public Transform itemsContainer;
    public GameObject itemPrefab;


    void Start()
    {
		if (items != null) {
			for (int i = 0; i < items.items.Length - 1; i++)
			{
				GameObject item = Instantiate(itemPrefab) as GameObject;
				item.GetComponent<ShopItemEntry>().LoadItem(items.items[i]);
				item.transform.SetParent(itemsContainer);
				item.transform.localScale = new Vector3(1, 1, 1);
			}
		}
    }

    void AddItem(Item item)
    {
        GameObject itemObject = Instantiate(itemPrefab) as GameObject;
        itemObject.GetComponent<ShopItemEntry>().LoadItem(item);
        itemObject.transform.SetParent(itemsContainer);
        itemObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
