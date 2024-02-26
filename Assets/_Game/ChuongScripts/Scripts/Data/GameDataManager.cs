namespace ChuongCustom
{
    using UnityEngine;

    public class Constant
    {
        public static string DataKey_PlayerData = "player_data";
        public static string DataKey_SettingData = "setting_data";
    }


    [DefaultExecutionOrder(-100)]
    public partial class GameDataManager : PersistentSingleton<GameDataManager>
    {
        /*----Scriptable data-----------------------------------------------------------------------------------------------*/


        /*----Data variable-------------------------------------------------------------------------------------------------*/
        [HideInInspector] public PlayerData playerData;
        [HideInInspector] public SettingData settingData;

        private void OnEnable()
        {
            playerData = new GameObject(Constant.DataKey_PlayerData).AddComponent<PlayerData>();
            playerData.transform.parent = transform;
            playerData.Init();
            playerData.ValidateData();

            settingData = new GameObject(Constant.DataKey_SettingData).AddComponent<SettingData>();
            settingData.transform.parent = transform;
            settingData.Init();
            settingData.ValidateData();
        }

        private void Start()
        {
            Application.targetFrameRate = Mathf.Max(60, Screen.currentResolution.refreshRate);
        }

        public void ResetData()
        {
            playerData.ResetData();
        }
    }
}