using UnityEngine;
using System.Collections;

public class Items : ScriptableObject{

	public Item[] items;
	
	public Item GetItemById(int id)
	{
		if (items == null)
			return null;
		for (int i = 0; i < items.Length; i++)
		{
			if (items[i].id == id)
			{
				return items[i];
			}
		}
		return items[0];
	}
}
