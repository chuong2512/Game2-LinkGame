namespace ChuongCustom
{
    public interface IPopup
    {
        public void OnOpen();
        public bool IsActive { get; set; }
        public void SetActive(bool b);
        public void CloseView();
        public void Back();
        public void Show();
        public void Hide();
    }
}