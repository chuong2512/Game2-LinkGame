using UnityEngine;
using System.Collections;

[System.Serializable]
public class Bonus
{
    public int exp = 0;
    public int gold = 0;
    public int time = 0;
    public int specicalBlock = 0;
    public int startScore = 0;
    public int exludeBlock = 0;

    public new string ToString()
    {
        string s = "+{0}{1}{2}";
        string[] args = new string[3];
        if (exp > 0)
        {
            args[0] = exp.ToString();
            args[1] = "%";
            args[2] = "exp";
			return string.Format(s, args);
        }
        else if (gold > 0)
        {
            args[0] = gold.ToString();
            args[1] = "%";
            args[2] = "Gold";
			return string.Format(s, args);
        }
        else if (time > 0)
        {
            args[0] = time.ToString();
            args[1] = "";
            args[2] = "s";
			return string.Format(s, args);
        }
        else
        {
			s = "+0%";
			return string.Format(s, args);
        }
        
    }
}
