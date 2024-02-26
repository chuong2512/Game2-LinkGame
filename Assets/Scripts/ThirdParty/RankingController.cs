using UnityEngine;
using System.Collections;

public class RankingController : MonoBehaviour {
    private static RankingController _instance;
    public static RankingController instance
    {
        get
        {
            if (_instance == null) _instance = new RankingController();
            if (FacebookController.instance == null)
            {
                GameObject facebook = new GameObject("Facebook");
                FacebookController.instance = facebook.AddComponent<FacebookController>();
            }
            return _instance;
        }
    }

    public void ReportScore(int score)
    {
        FacebookController.instance.PostScore(score);
    }
}
