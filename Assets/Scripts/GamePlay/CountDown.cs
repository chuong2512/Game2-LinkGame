using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public Image image;
    public Sprite[] sprites;
    int count = 0;

	void Awake()
	{
		GameManager.instance.SetGameState (GameState.STARTGAMEPLAY);
	}

    public void Count()
    {
		if (count == 1)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.COUNT03_START);
		if(count == 2)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.COUNT02_START);
		if(count == 3)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.COUNT01_START);
		if(count == 4)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.START);
        if (count >= sprites.Length)
        {
            GameManager.instance.SetGameState(GameState.PLAYING);
            Destroy(gameObject);
            return;
        }

		image.sprite = sprites[count];
		count++;

    }
}
