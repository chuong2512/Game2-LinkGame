using UnityEngine;

namespace ChuongCustom
{
    public abstract class BaseIAPButton : AButton
    {
        [SerializeField] private string package_id = "mua_vang_goi_1";

        protected override void OnClickButton()
        {
            IAPManager.OnPurchaseSuccess = OnBuySuccess;
            IAPManager.Instance.BuyProductID(package_id);
        }
        protected abstract void OnBuySuccess();
        protected abstract override void OnStart();
    }
}