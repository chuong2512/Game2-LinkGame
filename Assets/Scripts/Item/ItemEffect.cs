using UnityEngine;
using System.Collections;

public class ItemEffect :MonoBehaviour, BlockObserver{

	ItemInterface item = null;

	public BlockType type ;

	public static ItemEffect instance;

	void Awake() {
		instance = this;
	}

	public  void LoadItem() {
		int id = Attributes.selectedItem;

		switch(id) {
		case 1:
			item = CarController.instance;
			break;
		case 2: //binh tuoi
			item = Bottle.instance;
			break;
		case 3://luoi hai
			item = Scythe.instance;
			break;
		case 4: //bu nhin rom
			item = Scaresrow.instance;
			break;
		default:
			item = null;
			break;
		}
	}


	public  void Execute() {
		if (item != null)
			item.CheckRunConditon (type);
	}

}
