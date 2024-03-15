using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public class BuyCoinBtn : BaseIAPButton
    {
        [SerializeField] private int _amount;
        [SerializeField] private Text _amountText;

        private PlayerData _player;

        protected override void OnStart()
        {
            _player = GameDataManager.Instance.playerData;

            _amountText.text = $"x{_amount}";
        }

        protected override void OnBuySuccess()
        {
            Attributes.AddGem(_amount);
        }
    }
}