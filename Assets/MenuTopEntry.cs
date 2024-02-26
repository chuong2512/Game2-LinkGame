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
		txtMedal.text = t.GetMedal ().ToString ();
		int i = Random.Range (0, 12);
		avatarImg.sprite = avr.avatars[i].sprite;
		medalImg.sprite = top.medal [1];
		backGround.sprite = top.backgroud [1];
	}
	public void LoadMe(UserInfo me)
	{
		txtLevel.text = me.GetLevel().ToString();
		txtScore.text = me.GetHighScore().ToString();
		avatarImg.sprite = avr.GetAvatarById (Attributes.selectedAvatar).sprite;
		medalImg.sprite = top.medal [0];
		txtMedal.text = "";
		backGround.sprite = top.backgroud [0];
	}
}
