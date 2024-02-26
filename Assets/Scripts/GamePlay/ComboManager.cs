using UnityEngine;
using System.Collections.Generic;

public class ComboManager : MonoBehaviour {

	int combo;

	public float startTime;

	public static float timeCombo = 3.0f;

	public bool isCombo = false;

    public BonusText bonusText;

	public static ComboManager instance;

	void Awake()
	{
		instance = this;
	}
	
	void Start()
	{
		combo = 1;
	}

	// Update is called once per frame
	void Update ()
	{
		if(GameManager.instance.gameState == GameState.PLAYING)
			startTime += Time.deltaTime;
        //if(isCombo)
        //	if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.BLOCK_YELL);

        if (startTime > timeCombo)
        {
            combo = 1;
            if (isCombo)
            {
                BoardManager.instance.ChangeAllToNormal();
                //if (SoundManager.instance != null) SoundManager.instance.StopPlaySFX(SFX.BLOCK_YELL);
                if (SoundManager.instance != null)
                {
                    SoundManager.instance.StopLoopSFX();
                    SoundManager.instance.PlaySFX(SFX.MISS_COMBO);
                }
            }
            isCombo = false;
        }

    }

	//Tang combo
	public void Count()
	{
		combo += 1;
		if (combo == 8) 
		{
			BoardManager.instance.ChangeAllToExcited();
            SoundManager.instance.PlaySFX(SFX.BLOCK_YELL, 8);
			isCombo = true;
		}
	}

	public int GetCombo()
	{
		return combo >= 6 ? combo-5: 1;
	}

	public void ResetStartTime()
	{
		startTime = 0;
	}

    public void CheckCombo()
    {
		if (isCombo) 
		{
			string combosText = "Combos x " + (combo - 8);
			ActiveCombos(combosText);
		}
    }

	public void ActiveCombos(string combosText)
	{
		startTime = 0;
		List<Block> blocks = BoardManager.instance.GetPath();
		Vector3 pos = blocks[blocks.Count - 1].transform.position;
		pos.z = 1;
		bonusText.Open(combosText, pos);
	}
}
