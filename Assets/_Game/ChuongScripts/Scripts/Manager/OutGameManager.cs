using System;
using ChuongCustom;

public class GameAction
{
    public static Action<int> OnChangeGem;
    public static Action<int> OnChangeCoin;
    public static Action<int> OnChangeExp;
    public static Action<float> SetRegisterTime;
    public static Action<bool> OnSoundChange;
    public static Action<bool> OnSFXChange;
    public static Action<bool> OnVibrateChange;
}

public class OutGameManager : Singleton<OutGameManager>
{
}