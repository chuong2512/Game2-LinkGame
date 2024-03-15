namespace ChuongCustom
{
    public abstract class AShopBtn : AButton
    {
        protected override void OnClickButton()
        {
            if (IsEnoughResource())
            {
                OnBuySuccess();
            }
            else
            {
                ShowNotEnoughMoney();
            }
        }

        protected abstract void ShowNotEnoughMoney();
        protected abstract bool IsEnoughResource();
        protected abstract void OnBuySuccess();
        protected abstract override void OnStart();
    }
}