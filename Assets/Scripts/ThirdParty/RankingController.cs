using UnityEngine;
using System.Collections;

public class RankingController : MonoBehaviour {
    private static RankingController _instance;
    public static RankingController instance
    {
        get
        {
            if (_instance == null) _instance = new RankingController();
            return _instance;
        }
    }
    
    public void ReportScore(int score)
    {
        return;
    }
}
