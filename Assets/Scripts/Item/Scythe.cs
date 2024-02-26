using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scythe : ItemInterface {

	int count = 0;

	int currentTime = 0;

	public static Scythe instance ;

	SpecialBlockEffect eff;

	bool isRunning = false;
	

	void Awake() {
		timeConditionActive = 2;
		type = BlockType.Tomato;
		gameObject.SetActive (false);
		instance = this;
	}

	override
	public void CheckRunConditon(BlockType type) {
		Debug.Log ("asda");
		if (this.type == type) {
			++currentTime;
			if (currentTime == timeConditionActive)
				SetRun();
		} else {
			currentTime = 0;
		}
	}

	override
	public void SetRun() {

		GameManager.instance.SetGameState (GameState.EFFECT);
		eff = new SpecialBlockEffect(BoardManager.instance);
		List<Block> blocks = new List<Block> ();

		int row = Random.Range (0,BoardManager.instance.height);
		int col = Random.Range (0,BoardManager.instance.width);

		transform.position = BoardManager.instance.GetBlock (row, col).transform.position;

		Block block;
		for (int i = row -1; i <= row + 1; ++i) {
			for (int j = col - 1; j <= col +1; ++j) {
				if (i >= 0 && j >= 0 && j < BoardManager.instance.width && i < BoardManager.instance.height ) {
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
			SoundManager.instance.PlaySFX (SFX.LUOIHAI);
		isRunning = true;
		count = 0;
	}

	// Update is called once per frame
	void Update () {
		if (isRunning) {
			if (count == 2) {
				isRunning = false;
				gameObject.SetActive(false);
				count = 0;

				Block.observers.Clear();
				//Block.numBlock = 0;
				//Block.numHandled = 0;
				Block.PrepareEatBlock();
				if (eff.specialBlocks.Count > 0)
					Block.observers.Add(eff);
				else 
					Block.observers.Add(GameManager.instance);
				BoardManager.instance.EatBlocks(EatType.SpecialEat);
				currentTime = 0;
			}
		}
	}

	void Count() {
		++count;
	}
}
