namespace ChuongCustom
{
    public abstract class BaseScreenWithModel<TModel> : BaseScreen
    {
        public abstract void BindData(TModel model);
    }
}