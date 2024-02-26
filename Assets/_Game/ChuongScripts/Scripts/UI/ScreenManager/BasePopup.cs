using UnityEngine;

namespace ChuongCustom
{
    public abstract class BasePopup : MonoBehaviour, IPopup
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        public abstract ScreenType GetID();

        protected virtual void OnValidate()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void OnOpen()
        {
        }

        public bool IsActive { get; set; }

        public virtual void SetActive(bool b)
        {
            IsActive = b;
            _canvasGroup.alpha = b ? 1 : 0;
            gameObject.SetActive(b);
        }

        /// <summary>
        /// Close popup
        /// </summary>
        public virtual void CloseView()
        {
            transform.SetParent(ScreenManager.Instance.ClosingPopups);
            SetActive(false);
        }

        public virtual void Back()
        {
            ScreenManager.Instance.Back();
            MasterAudioManager.ClickSound();
        }

        /// <summary>
        /// Show when back to nearesrt popup
        /// </summary>
        public virtual void Show()
        {
            transform.SetParent(ScreenManager.Instance.OpeningPopups);
            transform.SetAsLastSibling();
            SetActive(true);
        }

        /// <summary>
        /// Hide when open another popup
        /// </summary>
        public virtual void Hide()
        {
            SetActive(false);
        }

        /// <summary>
        /// Move tranforms to ClosingPopups when click Close Button
        /// </summary>
        public virtual void Remove()
        {
            transform.SetParent(ScreenManager.Instance.ClosingPopups);
            SetActive(false);
        }

        public virtual void Add()
        {
            transform.SetParent(ScreenManager.Instance.OpeningPopups);
            transform.SetAsLastSibling();
            SetActive(true);
            OnOpen();
        }
    }
}