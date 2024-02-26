using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scaresrow : ItemInterface {

	public static Scaresrow instance;

	SpecialBlockEffect eff;

	int currentTime = 0;

	void Awake() {
		timeConditionActive = 3;
		type = BlockType.Sun;
		gameObject.SetActive (false);
		instance = this;
	}

	override
	public void CheckRunConditon(BlockType type) {
		++currentTime;
		if (currentTime == timeConditionActive) {
			SetRun ();
		}
	}

	override
	public void SetRun() {
		GameManager.instance.SetGameState (GameState.EFFECT);

		eff = new SpecialBlockEffect(BoardManager.instance);
		List<Block> blocks = new List<Block> ();
		
		int row = Random.Range (0,BoardManager.instance.height);
		int col = Random.Range (0,BoardManager.instance.width);

		Vector3 position = BoardManager.instance.GetBlock (row, col).transform.position;
		position.y += Block.diff;
		position.x += 0.4f * Block.diff;
		position.z = -3; 
		transform.position = position;

		Block block;
		for (int i = row -1; i <= row + 1; ++i) {
			for (int j = col - 1; j <= col +1; ++j) {
				if (i >= 0 && j >= 0 && j < BoardManager.instance.width && i < BoardManager.instance.height ) {
					if (i == row - 1 && j == col-1 || i == row + 1 && j == col-1 || i == row - 1 && j == col + 1 || i == row + 1 && j == col + 1)
						continue;
					block = BoardManager.instance.GetBlock(i, j);
					if (!Block.IsSpecialBlock(block))
						blocks.Add(block);
					else {
						eff.AddSpecialBlock(block);
					}
					block.SetState(BlockState.Selected);
				}
			}
		}
		
		for (int i = 0; i < blocks.Count; ++i) {
			if (!BoardManager.instance.GetPath().Contains(blocks[i]))
				BoardManager.instance.GetPath().Add(blocks[i]);
		}
		
		gameObject.SetActive (true);
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.BUNHIN);
	}
	
	void Finish() {
		gameObject.SetActive(false);
		
		Block.observers.Clear();
		Block.PrepareEatBlock ();
		//Block.numBlock = 0;
		//Block.numHandled = 0;
		if (eff.specialBlocks.Count > 0)
			Block.observers.Add(eff);
		else 
			Block.observers.Add(GameManager.instance);
		BoardManager.instance.EatBlocks(EatType.SpecialEat);
		currentTime = 0;
	}
	
}

