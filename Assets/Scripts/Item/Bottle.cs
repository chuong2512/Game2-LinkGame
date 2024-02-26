using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bottle : ItemInterface {

	SpecialBlockEffect eff;

	int currentTime = 0;

	public static Bottle instance;

	public static BlockType eatType = BlockType.Carrot;

	void Awake() {
		timeConditionActive = 2;
		type = BlockType.Purpleonion;
		gameObject.SetActive (false);
		instance = this;
	}

	override
	public void CheckRunConditon(BlockType type) {
		if (this.type == type) {
			++currentTime;
			if (currentTime == timeConditionActive) {
				SetRun ();
			}
		} else {
			currentTime = 0;
		}
	}

	override
	public void SetRun() {
		GameManager.instance.SetGameState (GameState.EFFECT);
		gameObject.SetActive (true);
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.CAUVONG);


		List<Block> blocks = new List<Block> ();

		Block block;
		for (int row = 0; row  < BoardManager.instance.height; ++row) {
			for (int col = 0; col < BoardManager.instance.width; ++col) {
				block = BoardManager.instance.GetBlock(row,col);
				if (block.type == eatType) {
					blocks.Add(block);
					block.SetState(BlockState.Selected);
				}
			}
		}

		for (int i = 0; i < blocks.Count; ++i) {
			if (!BoardManager.instance.GetPath().Contains(blocks[i]))
				BoardManager.instance.GetPath().Add(blocks[i]);
		}


	}

	public void Finish() {

		currentTime = 0;
		gameObject.SetActive(false);

		if (BoardManager.instance.GetPath ().Count == 0) {
			GameManager.instance.SetGameState(GameState.PLAYING);
			return;
		}

		Block.observers.Clear();
		//Block.numBlock = 0;
		//Block.numHandled = 0;
		Block.PrepareEatBlock ();
		Block.observers.Add(GameManager.instance);
		BoardManager.instance.EatBlocks(EatType.SpecialEat);
	}
}
