using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Facebook.Unity;

public class MenuFriendEntry : MonoBehaviour {

	public static MenuFriendEntry instance;
	public Image avatarImg;
	public Text txtMedal;
	public Text txtLevel;
	public Text txtScore;
	public Avatars avr ;
	public Image medalImg;
	public Image backGround;
	public Top top;

	void Awake(){
		instance = this;
	}

	void Start(){
		QueryScores ();
	}

	public void LoadFriend(UserInfo t)
	{
		txtLevel.text = t.GetLevel().ToString();
		txtScore.text = t.GetHighScore().ToString();
		txtMedal.text = t.GetMedal ().ToString ();
		int i = Random.Range (0, 12);
		avatarImg.sprite = avr.avatars[i].sprite;
		medalImg.sprite = LoadMedal(t.GetMedal());
		backGround.sprite = top.backgroud [2];
	}
	public void LoadMe(UserInfo me)
	{
		txtLevel.text = me.GetLevel().ToString();

		//txtScore.text = me.GetHighScore().ToString();
		int score;
		//FacebookController.instance.QueryScores ();

		avatarImg.sprite = avr.GetAvatarById (Attributes.selectedAvatar).sprite;
		medalImg.sprite = LoadMedal(1);
		txtMedal.text = me.medal.ToString();
		backGround.sprite = top.backgroud [0];
	}

	public void QueryScores(){
		if(FacebookController.instance.IsLoggedIn() && RandomDataFacebook.instance.isConnection)
			FB.API("/app/scores?fields=score,user.limit(30)", HttpMethod.GET, ScoresCallback);
		else{
			Debug.Log("Nhu cut: " + FacebookController.instance.IsLoggedIn());
			txtScore.text = Attributes.GetHighScore().ToString();
		}
	}
	
	private void ScoresCallback(IResult result)
	{
		Debug.Log ("Scores callback: " + result.RawResult);
		txtScore.text = result.RawResult;
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
