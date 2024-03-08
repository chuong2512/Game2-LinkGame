using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadTime : MonoBehaviour {

	public float countTime;
	public float k;
	public float timePlay = 5.0f;
	public Image load;
	public Text timeText;
	public float timeOver; // bien dem thoi gian, neu = 0 => gameover
	public float time;
	private bool ready = false;
	private bool viewItem = false;

	public float timeScale = 1.0f;

	public static LoadTime instance;

	void Awake()
	{
		instance = this;
		k = Time.deltaTime+1;
		countTime = Time.deltaTime;
		timeOver = timePlay;
		time = timePlay;
	}

	void Start () {
	}

	// Load 60s
	void Update () {

		timeText.text = TimeConvert.GetTimeText(timeOver);
		if (GameManager.instance.gameState == GameState.PLAYING && GameManager.instance.timeScale > 0) 
		{
			gameObject.SetActive(true);
			countTime += Time.deltaTime;
			if ((countTime > k) && (k < time + 1)) {
				k = k + 1;
				load.fillAmount = load.fillAmount - 1.0f / timePlay;
				if (timeOver > 0)
					timeOver = timeOver - 1;
				if(timeOver == 7)
					//Kich hoat am thanh gan het gio
					if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER(STARTOVER.LAST_7S);

				//Load item khi 50s cuoi

				if(timeOver == 50 && viewItem == false)
				{
					HUDController.instance.LoadItem();
					viewItem = true;
					ItemEffect.instance.LoadItem();
				}


				if (timeOver <=0 )
				{
					timeOver = 0;
					//Kich hoat am thanh gan het gio
					if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER(STARTOVER.TIME_OVER);
					//An het cac quan dac biet tren man choi
					GameManager.instance.SetGameState(GameState.EFFECT);
					BoardManager.instance.AutoEatSpecialBlock();
				}
			}
		}
	}

	public void AddTime(int addTime)
	{
		load.fillAmount = load.fillAmount + addTime / timePlay;
		time = time + addTime;//Add time
		timeOver = timeOver + addTime;
		if (timeOver > 7) 
		{
			if(SoundManager.instance != null) SoundManager.instance.StopPlaySTART_OVER(STARTOVER.LAST_7S);
		}
		if (timeOver >= timePlay)
			timePlay = timeOver;
	}

}

public static class TimeConvert
{
	public static string GetTimeText(int second)
	{
		var minutes = second / 60;
		var remainingSeconds = second % 60;
		return $"{minutes:D2}:{remainingSeconds:D2}";
	}
	
	public static string GetTimeText(float second)
	{
		return GetTimeText((int)second);
	}
}
