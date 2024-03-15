using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

public class UIController : MonoBehaviour
{
    public Popup highScorePopup;
    public Popup newRankingPopup;
    public Popup resultPopup;
    public Popup levelUpPopup;

    public static UIController instance;

    bool isHighScore = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        resultPopup.onCloseEvent = () => { LoadingScreen.Load(Scenes.MAIN_MENU); };
        highScorePopup.onCloseEvent = () => { LoadingScreen.Load(Scenes.MAIN_MENU); };
    }
    
    [Button]
    public void ShowResult(int score = 0, int gold = 0, int exp = 0)
    {
        HUDController.instance.gameObject.SetActive(false);
        isHighScore = Attributes.SetHighScore(score);

        string bonus = GameManager.instance.selectedAvatar.bonus.ToString();
        Attributes.AddGold(gold);

        string[] content = {
                score.ToString(),
                Attributes.GetHighScore().ToString(),
                gold.ToString(),
                exp.ToString(),
                bonus,
            };
        Sprite[] sprites =
        {
            GameManager.instance.selectedAvatar.sprite
        };


        //Checl level up
        int currentExp = Attributes.GetCurrentExp() + exp;
        int gemBonus = 1;
        bool checkLevelup = false;
        int currentLevel = Attributes.GetCurrentLevel();
        do {
            if (Attributes.CheckLevelUp(currentExp)) {
                currentExp -= Attributes.TotalExpToLevelUp();
                Attributes.SetLevelUp();
                checkLevelup = true;
            }
        } while (Attributes.CheckLevelUp(currentExp));
        Attributes.SetCurrentExp(currentExp);

        if (checkLevelup)
        {
            gemBonus = Attributes.GetCurrentLevel() - currentLevel;
			if(gemBonus > 0)
            	Attributes.AddGem(gemBonus);
            string[] contentLevelUp = {
                Attributes.currentLevel.ToString (),
                gemBonus.ToString ()
            };
            levelUpPopup.Open(contentLevelUp, sprites);
			if (isHighScore) {
				levelUpPopup.onCloseEvent = () => { highScorePopup.Open(content, sprites); };
			} else {
				levelUpPopup.onCloseEvent = () => { resultPopup.Open(content, sprites); };
			}
        } else {
			if (isHighScore)
			{
				highScorePopup.Open(content, sprites);
			}
			else
			{
				resultPopup.Open(content, sprites);
			}
		}
        EventController.instance.OnResult();

		//Delete avatar & item
		Attributes.DeleteAvatar (Attributes.selectedAvatar);//Xoa avatar da dung ra khoi danh sach avatar purchase
		Attributes.DeleteItem (Attributes.selectedItem);//Xoa item da dung ra khoi danh sach avatar purchase
    }
}
