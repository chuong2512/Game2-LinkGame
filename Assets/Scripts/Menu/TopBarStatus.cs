using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopBarStatus : MonoBehaviour
{
    public static TopBarStatus instance;
    public Text expPercent;
    public Text level;
    public Text gold;
    public Text gem;

    int goldAmount;
    int gemAmount;
    int levelAmount;
    int expAmount;

    const int unit = 100;

    public Image expProgress;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        DetectStatusChange();
    }

    public void RefreshStatus()
    {
		goldAmount = Attributes.GetGold();
		gemAmount = Attributes.GetGem();
		levelAmount = Attributes.GetCurrentLevel ();

        if (level != null)
			level.text = levelAmount.ToString ();
        if (gold != null)
			gold.text = goldAmount.ToString ();
        if (gem != null)
			gem.text = gemAmount.ToString ();
        if (expPercent != null)
            expPercent.text = CalPercentExp().ToString() + "%";
        FillMountExp();

    }

    void DetectStatusChange()
    {
        int goldChange = Attributes.GetGold() - goldAmount;
        if (Mathf.Abs(goldChange) > unit)
        {
            int sign = (goldChange > 0) ? 1 : -1;
            goldAmount += unit * sign;
            gold.text = goldAmount.ToString();
        }
        else if (goldChange != 0)
        {
            goldAmount = Attributes.GetGold();
            gold.text = goldAmount.ToString();
        }

        int gemChange = Attributes.GetGem() - gemAmount;
        if (Mathf.Abs(gemChange) > unit)
        {
            int sign = (gemChange > 0) ? 1 : 1;
            gemAmount += sign * unit;
            gem.text = gemAmount.ToString();
        }
        else if (gemChange != 0)
        {
            gemAmount = Attributes.GetGem();
            gem.text = gemAmount.ToString();
        }

		RefreshStatus ();
    }

    private int CalPercentExp()
    {
        int exp = (int)(Attributes.GetCurrentExp() * 100 / Attributes.TotalExpToLevelUp());
        return exp;
    }

    private void FillMountExp()
    {
        expProgress.fillAmount = (float)Attributes.GetCurrentExp() / Attributes.TotalExpToLevelUp();
    }
}
