using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChuongCustom
{
    public enum ScreenType
    {
        Back = -1,
        HomeScreen = 0,
        IAPScreen,
        RegisterScreen,
        SetTimePopup,
        RateGame,
        HUD,
        Setting,
        SelectMap,
        AddSkill,
        Pause,
        Result,
        Privacy,
        EquipmentInfo
    }

    [DefaultExecutionOrder(-99)]
    public class ScreenManager : Singleton<ScreenManager>
    {
        [SerializeField] private BasePopup[] _screens;

        private List<BasePopup> _listScreens = new List<BasePopup>();
        private BasePopup _currentScreen;

        [SerializeField] private Transform _openingPopups, _closingPopups;
        [SerializeField] private Transform _overlay;

        public Transform OpeningPopups => _openingPopups;
        public Transform ClosingPopups => _closingPopups;
        public BasePopup CurrentScreen => _currentScreen;

#if UNITY_EDITOR
        public string folderPath = "";

        [Button]
        public void OnValidate()
        {
            var spriteGUIDs = UnityEditor.AssetDatabase.FindAssets("t:Prefab", new[] {folderPath});

            var listScreen = new List<BasePopup>();

            int n = spriteGUIDs.Length;

            for (int i = 0; i < n; i++)
            {
                string audioPath =
                    UnityEditor.AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]); // Chuyển đổi GUID sang đường dẫn
                var popup = UnityEditor.AssetDatabase.LoadAssetAtPath<BasePopup>(audioPath); // Tải T từ đường dẫn

                if (popup != null)
                {
                    listScreen.Add(popup);
                }
            }

            _screens = listScreen.ToArray();
        }
#endif

        private void Start()
        {
            OpenScreen(ScreenType.HomeScreen);
        }


        [Button]
        public void OpenScreen(ScreenType screenType)
        {
            if (_currentScreen != null)
            {
                if (_currentScreen is BaseScreen)
                {
                    _currentScreen.Hide();
                }
                else
                {
                    _currentScreen.CloseView();
                }
            }

            BasePopup screen = _listScreens.Find(s => s.GetID() == screenType);

            if (screen == null)
            {
                screen = Instantiate(_screens.ToList().Find(popup => popup.GetID() == screenType), transform);
                _listScreens.Add(screen);
            }

            _overlay.gameObject.SetActive(screen.GetID() != ScreenType.HomeScreen);

            _overlay.SetAsLastSibling();
            screen.Add();
            _currentScreen = screen;
        }

        [Button]
        public void OpenScreen<TModel>(ScreenType screenType, TModel tModel)
        {
            OpenScreen(screenType);
            var c = (BaseScreenWithModel<TModel>) _currentScreen;
            c.BindData(tModel);
        }


        [Button]
        public void Back()
        {
            _overlay.SetAsFirstSibling();
            _overlay.gameObject.SetActive(false);

            int childCount = _openingPopups.childCount;

            if (childCount >= 2 && _currentScreen != null)
            {
                _currentScreen.Remove();
                _currentScreen = _openingPopups.GetChild(childCount - 2).GetComponent<BasePopup>();
                _currentScreen.Show();
            }
        }
    }
}