using UnityEngine;
using System.Collections;

public enum GameState
{
    PLAYING,
    SHOPING,
    PAUSE,
    GAMEOVER,
    EFFECT,
    STARTGAMEPLAY,
    RESULT,
}

public class GameManager : MonoBehaviour, BlockObserver
{
    public float timeScale = 1.0f;
    public static GameManager instance;

    public int currentScore;
    public int currentExp;

    public float effectAvatarToExp = 0;
    public float effectAvatarToGold = 0;

    public GameState gameState;

    public Avatars avatars;
    public Items items;

    public Avatar selectedAvatar;
    public Item selectedItem;
    public BackGroundController backGround;
    public EndGameEffect endGame;

    public bool paused = false;

    public PauseController pauseControl;

    void Awake()
    {
        instance = this;
        Debug.Log("Level : " + Attributes.GetCurrentLevel());
        Debug.Log("Gem: " + Attributes.GetGem());
    }

    void Start()
    {
        currentScore = 0;
        if (avatars != null && Attributes.selectedAvatar != 0)
            selectedAvatar = avatars.GetAvatarById(Attributes.selectedAvatar);
        if (items != null && Attributes.selectedItem != 0)
            selectedItem = items.GetItemById(Attributes.selectedItem);
        SoundManager.instance.PlayBGM(BGM.GAME_DAY, BGM.GAME_NIGHT);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                SetGameState(GameState.PAUSE);
                pauseControl.Open();
            }
        }
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        Debug.Log("Game State: " + state);
        CheckGameStateChange();
    }

    public void CheckGameStateChange()
    {
        switch (gameState)
        {
            case GameState.GAMEOVER:
                endGame.Open();
                break;
            case GameState.PLAYING:
                if (BoardManager.instance.IsEmptyBoardGameStatus())
                    BoardManager.instance.BoardInit();

                break;
            case GameState.PAUSE:
                break;
            case GameState.EFFECT:
                break;
            case GameState.STARTGAMEPLAY:
                break;
            case GameState.RESULT:
                backGround.ViewResultBackGround();
                currentScore = ScoreCalculator.instance.GetScore();
                UIController.instance.ShowResult(currentScore, CalGold(currentScore), CalExp(currentScore));
                break;
        }
    }

    public int CalExp(int scoreGameplay)
    {
        if (selectedAvatar != null && selectedAvatar.id == Strings.AVATAR_NAMI) //truong hop bat dau tu 500.000d
            scoreGameplay -= 500000;
        int exp = (int)scoreGameplay / 1000 + (int)(effectAvatarToExp * scoreGameplay / 1000);
        return exp;
    }

    public int CalGold(int scoreGameplay)
    {
        int gold = 0;
        if (selectedAvatar != null && selectedAvatar.id == Strings.AVATAR_NAMI) //truong hop bat dau tu 500.000d
            scoreGameplay -= 500000;
        gold = (int)(scoreGameplay / 10000);
        if (gold > 0)
            return gold;
        return 0;
    }

    public void Execute()
    {
        SetGameState(GameState.PLAYING);
    }
}

