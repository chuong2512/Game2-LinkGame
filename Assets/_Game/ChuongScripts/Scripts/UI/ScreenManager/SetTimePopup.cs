using System;
using DG.Tweening;
using UnityEngine;

namespace ChuongCustom
{
    public class SetTimePopup : BasePopup
    {
        [SerializeField] private SetTimeButton[] _setTimeButtons;

        public override void OnOpen()
        {
            base.OnOpen();
            transform.DOKill();
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -800);
            GetComponent<RectTransform>().DOAnchorPosY(90, 0.5f);
        }

        public override ScreenType GetID()
        {
            return ScreenType.SetTimePopup;
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            _setTimeButtons = GetComponentsInChildren<SetTimeButton>();
        }

        private void Start()
        {
            for (int i = 0; i < _setTimeButtons.Length; i++)
            {
                _setTimeButtons[i].SetTime(i);
            }
        }
    }
}