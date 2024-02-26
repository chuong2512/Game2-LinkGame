using UnityEngine;
using System.Collections;

[System.Serializable]
public class Avatar {

	public int id;
	public string name = "";
	public string description = "";
	public int gold;
	public int gem;
	public int timeeffect;
	public Sprite sprite;
    public Bonus bonus;
}
