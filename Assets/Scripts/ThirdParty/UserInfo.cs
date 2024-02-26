using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInfo {

	public int medal;
	public Sprite avatar;
	public int level;
	public int highScore;
	public int rank;

	public void SetMedal(int medal){
		this.medal = medal;
	}

	public int GetMedal(){
		return medal;
	}

	public void SetLevel(int level){
		this.level = level;
	}

	public int GetLevel(){
		return level;
	}

	public void SetHighScore(int highScore){
		this.highScore = highScore;
	}

	public int GetHighScore(){
		return highScore;
	}

	public void SetRank(int rank){
		this.rank = rank;
	}

	public int GetRank(){
		return rank;
	}
}
