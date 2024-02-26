using UnityEngine;

namespace ChuongCustom
{
    public class IAPScreen : AppPopup
    {
        [SerializeField] private BuyCoinButton[] _buttons;

        protected override void Start()
        {
            base.Start();

            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Index = i;
            }
        }

        public override void OnOpen()
        {
        }

        public override ScreenType GetID() => ScreenType.IAPScreen;
    }
}