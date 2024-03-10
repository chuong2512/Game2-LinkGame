using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class MenuTopEntry : MonoBehaviour {
	public Image avatarImg;
	public Text txtMedal;
	public Text txtLevel;
	public Text txtScore;
	public Avatars avr ;
	public Image medalImg;
	public Image backGround;
	public Top top;
	
	public void LoadTop(UserInfo t)
	{
		txtLevel.text = t.GetLevel().ToString();
		txtScore.text = t.GetHighScore().ToString();
		var medal = t.GetMedal();
		txtMedal.text = medal.ToString ();
		int i = Random.Range (0, 12);
		avatarImg.sprite = avr.avatars[i].sprite;
		medalImg.sprite = LoadMedal(medal);
		backGround.sprite = top.backgroud [1];
	}
	public void LoadMe(UserInfo me)
	{
		txtLevel.text = me.GetLevel().ToString();
		txtScore.text = me.GetHighScore().ToString();
		avatarImg.sprite = avr.GetAvatarById (Attributes.selectedAvatar).sprite;
		medalImg.sprite = LoadMedal(me.medal);
		txtMedal.text = me.medal.ToString();
		backGround.sprite = top.backgroud [0];
	}

	public Sprite LoadMedal(int topMedal)
	{
		if (topMedal > 3)
		{
			txtMedal.gameObject.SetActive(true);
			return top.medal[3];
		}
		txtMedal.gameObject.SetActive(false);
		return top.medal[topMedal - 1];
	}
}
