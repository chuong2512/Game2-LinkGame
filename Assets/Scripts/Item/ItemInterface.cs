using UnityEngine;
using System.Collections;

public abstract class ItemInterface : MonoBehaviour{
	protected int timeConditionActive;
	
	protected BlockType type;


	public abstract void  CheckRunConditon (BlockType type);

	public abstract void SetRun();
}
