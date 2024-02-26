
using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public class RegisterScreen : AppScreen
    {
        [SerializeField] private BuyTimeButton[] _buttons;
        [SerializeField] private TextMeshProUGUI _text;

        protected override void Start()
        {
            base.Start();

            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Index = i;
            }
        }

        public override ScreenType GetID()
        {
            return ScreenType.RegisterScreen;
        }

        public override void Back()
        {
            if (GameDataManager.Instance.playerData.time > 0)
            {
                base.Back();
            }
        }
    }
}