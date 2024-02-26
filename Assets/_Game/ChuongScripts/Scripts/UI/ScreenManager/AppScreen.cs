using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public abstract class AppScreen : BaseScreen
    {
        [SerializeField] private Button _closeBtn;

        protected virtual void Start()
        {
            _closeBtn?.onClick.AddListener(Back);
        }
    }
}