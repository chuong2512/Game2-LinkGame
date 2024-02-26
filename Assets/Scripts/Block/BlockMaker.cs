using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockMaker : MonoBehaviour 
{
	public List<GameObject> listBlocks;

	public List<GameObject> specialBlocks;

	public List<GameObject> listRuntimeBlock;


	public static BlockMaker instance;

	void Awake()
	{
		instance = this;
	}

	public Block RandomInstanceGameObject()
	{
		int id = Random.Range (0, listBlocks.Count);
		Block g = Instantiate(listBlocks[id]).GetComponent<NormalBlock>();
		return g;
	}

	public Block InstanceBlock(BlockType type)
	{
		Block block = null;

		for (int i = 0; i < listBlocks.Count; ++i)
		{
			if (listBlocks[i].GetComponent<Block>().type == type) {
				block =  Instantiate(listBlocks[i]).GetComponent<NormalBlock>();
			}
		}
		if (block != null)
			return block;
		for (int i = 0; i < specialBlocks.Count; ++i) 
		{
			if (specialBlocks[i].GetComponent<Block>().type == type) {
				block = Instantiate(specialBlocks[i]).GetComponent<SpecialBlock>();
			}
		}
		if (block != null)
			return block;
		for (int i = 0; i < listRuntimeBlock.Count; ++i) 
		{
			if (listRuntimeBlock[i].GetComponent<Block>().type == type)
				block = Instantiate(specialBlocks[i]).GetComponent<SpecialBlock>();
		}
		return block;
	}
	

	public void AddInstance(GameObject obj)
	{
		if (!listBlocks.Contains (obj))
			listBlocks.Add (obj);
	}


	public GameObject GetRuntimeBlock(BlockType type)
	{
		for (int i = 0; i < listRuntimeBlock.Count; ++i) 
		{
			if (listRuntimeBlock[i].GetComponent<NormalBlock>().type == type)
				return listRuntimeBlock[i];
		}
		return null;
	}
}
