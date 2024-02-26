using UnityEngine;

namespace ChuongCustom
{
    public class SettingData : BaseData
    {
        public bool Music = true;
        public bool Sound = true;
        public bool Vibration = true;

        public override void Init()
        {
            prefString = Constant.DataKey_SettingData;
            if (PlayerPrefs.GetString(prefString).Equals(""))
            {
                ResetData();
            }

            base.Init();
        }

        public void ClickSound(out bool isOn)
        {
            Sound = !Sound;
            isOn = Sound;

            GameAction.OnSoundChange?.Invoke(isOn);
        }

        public void ClickMusic(out bool isOn)
        {
            Music = !Music;
            isOn = Music;

            GameAction.OnSFXChange?.Invoke(isOn);
        }

        public void ClickVibration(out bool isOn)
        {
            Vibration = !Vibration;
            isOn = Vibration;

            GameAction.OnVibrateChange?.Invoke(isOn);
        }
    }
}