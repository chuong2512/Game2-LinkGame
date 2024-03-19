using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[DefaultExecutionOrder(-999)]
public class RandomDataFacebook : MonoBehaviour {

	public static RandomDataFacebook instance;
	public bool isConnection = false;
	public List<UserInfo> listUserInfo;
	private UserInfo meInfo ;
	
	void Awake(){
		instance = this;
	}

	void Start () {
		listUserInfo = new List<UserInfo>();
		isConnection = false;
		if (!isConnection) {
			meInfo = GetMeInfo ();
			listUserInfo = RandomData();
		}

	}
	public List<UserInfo> GetList()
	{
		return listUserInfo;
	}
	public UserInfo GetMe()
	{
		return meInfo;
	}
	
	public List<UserInfo> RandomData(){
		List<UserInfo> list = new List<UserInfo>();
		//Sinh du lieu nho hon
		int medal = 0;
		list.Add (meInfo);
		while(medal < meInfo.GetMedal()){
			list.Add(RandomUserInfoHigher());
			medal++;
		}
		
		//Sinh du lieu lon hon
		medal = meInfo.GetMedal() + 1;//Mang gom 10 phan tu
		while(medal < 10){
			list.Add(RandomUserInfoLower());
			medal++;
		}
		
		//Sap xep mang
		list = Sort (list);
		list = SetMedal (list);

		return list;
	}

	private UserInfo GetMeInfo(){
		UserInfo me = new UserInfo ();
		me.SetMedal (Random.Range (3, 7));
		me.SetLevel (Attributes.GetCurrentLevel());
		me.SetHighScore (Attributes.GetHighScore());
		return me;
	}
	
	private UserInfo RandomUserInfoLower(){
		UserInfo userTemp = new UserInfo ();
		userTemp.SetLevel(Random.Range((int) (0.5 * meInfo.GetLevel()), meInfo.GetLevel()));
		userTemp.SetHighScore(Random.Range((int)(0.5 * meInfo.GetHighScore()), meInfo.GetHighScore()));
		userTemp.SetRank(Random.Range((int)(0.5 * meInfo.GetRank()), meInfo.GetRank()));
		
		return userTemp;
	}
	
	private UserInfo RandomUserInfoHigher(){
		UserInfo userTemp = new UserInfo ();
		userTemp.SetLevel(Random.Range(meInfo.GetLevel(), 30 + meInfo.GetLevel()));
		userTemp.SetHighScore(Random.Range(meInfo.GetHighScore(), 50000 + meInfo.GetHighScore()));
		userTemp.SetRank(Random.Range(meInfo.GetRank(), 5 + meInfo.GetRank()));
		return userTemp;
	}
	
	private List<UserInfo> Sort(List<UserInfo> list){
		for (int i = 0; i < list.Count - 1; i ++) {
			for( int j = i + 1; j < list.Count; j++){
				if(list[i].GetHighScore() < list[j].GetHighScore()){
					UserInfo temp;
					temp = list[i];
					list[i] = list[j];
					list[j] = temp;
				}
			}
		}
		return list;
	}
	
	private List<UserInfo> SetMedal(List<UserInfo> list){
		for (int i = 0; i < list.Count; i++) {
			list[i].SetMedal(i + 1);
		}
		return list;
	}
}
