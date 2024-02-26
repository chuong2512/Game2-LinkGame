using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreCalculator: MonoBehaviour  {

	private int score = 0;

	public static ScoreCalculator instance;

	void Awake()
	{
		instance = this;
	}

	public void SetScore(int score)
	{
		this.score = score;

		if (score >= 50000)
		{
			BlockMaker.instance.AddInstance(BlockMaker.instance.GetRuntimeBlock(BlockType.Pumpkin));
			BlockMaker.instance.AddInstance(BlockMaker.instance.GetRuntimeBlock(BlockType.Pineapple));
		}

		if (score >= 100000) 
		{
			BlockMaker.instance.AddInstance(BlockMaker.instance.GetRuntimeBlock(BlockType.Eggplant));
		}

		if (score >= 200000) 
		{
			BlockMaker.instance.AddInstance(BlockMaker.instance.GetRuntimeBlock(BlockType.Corn));
		}

		if (score >= 450000) 
		{
			BlockMaker.instance.AddInstance(BlockMaker.instance.GetRuntimeBlock(BlockType.Chili));
		}
	}

	public int GetScore()
	{
		return score;
	}

	public void CalculateScore(List<Block> path, int currentCombo)
	{
		int score = 0;
		if (currentCombo < 1)
		{
			Debug.Log ("Error parameter combo: " + currentCombo);
			return ;
		}

		for (int i = 0; i < path.Count; ++i)
		{
			score += path[i].score* currentCombo;
		}

		SetScore (this.score + score);
	}
	
}
