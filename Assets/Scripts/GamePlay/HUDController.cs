using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUDController : MonoBehaviour
{

    public static HUDController instance;
    public Image avatar;
    public Image item;
    public Text itemDescription;
    public GameObject itemPopup;

    public Text score;
    int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        LoadAvatar();
		itemPopup.SetActive(false);
		StartCountScore ();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculator.instance.GetScore() > currentScore)
        {
            currentScore += 500;
            score.text = currentScore.ToString();
        }
    }

    /*
	 * LoadAvatar(): Load avatar active
	 * Input: id avatar
	 * Output: void
	 * 
	*/
    private void LoadAvatar()
    {
        Avatar avatar = GameManager.instance.selectedAvatar;
		if(avatar != null && avatar.sprite != null)
        	this.avatar.sprite = avatar.sprite;
    }

    public void LoadItem()
    {
		Item item = GameManager.instance.selectedItem;
		if (item.id != 0) {
			this.item.sprite = item.sprite;
			itemDescription.text = item.description;
			itemPopup.SetActive (true);
		} else {
			itemPopup.SetActive(false);
		}
    }

	private void StartCountScore()
	{
		if (Attributes.selectedAvatar == Strings.AVATAR_NAMI) 
		{
			//Neu la avatar co diem bat dau tu 500.000d
			currentScore = 500000;
			score.text = currentScore.ToString();
		}
	}
}
