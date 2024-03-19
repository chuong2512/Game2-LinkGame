using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TopController : MonoBehaviour {

	public Avatars avatars;
	public Transform topContainer;
	public GameObject menuTop;
	public List<UserInfo> list = new List<UserInfo>() ;
	public UserInfo me = new UserInfo ();
	public RandomDataFacebook random ;

	// Use this for initialization
	void Start () {
		random = RandomDataFacebook.instance;
		list = new List<UserInfo> ();
		list = random.RandomData ();
		me = random.GetMe ();
		if (list.Count == 0) {
			Debug.Log ("Co mang. Lay du lieu that");
		} else {
			foreach (UserInfo use in list){
				GameObject top = Instantiate (menuTop) as GameObject;
				if(use.GetMedal()!= me.GetMedal() ){
					top.GetComponent<MenuTopEntry> ().LoadTop (use);
				}
				else
				{
					top.GetComponent<MenuTopEntry>().LoadMe(use);
				}
				top.transform.SetParent (topContainer);
				top.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}


}
