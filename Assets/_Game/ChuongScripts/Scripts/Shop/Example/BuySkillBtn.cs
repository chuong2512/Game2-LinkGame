using System;
using ChuongCustom;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public class BuySkillBtn : AShopBtn
    {
        [SerializeField] private int _amount = 1, _price = 500;
        [SerializeField] private Text _amountText, _priceText;

        private PlayerData _player;

        protected override void OnStart()
        {
            _player = GameDataManager.Instance.playerData;
            _amountText.text = _amount.ToString();
            _priceText.text = _price.ToString();
        }

        protected override void ShowNotEnoughMoney()
        {
            ToastManager.Instance.ShowMessageToast("Not enough coin!!");
        }

        protected override bool IsEnoughResource()
        {
            return Attributes.GetGem() >= _price;
        }

        protected override void OnBuySuccess()
        {
            Attributes.AddGem(-_price);
            Attributes.AddGold(_amount);
            //todo:
        }
    }
}