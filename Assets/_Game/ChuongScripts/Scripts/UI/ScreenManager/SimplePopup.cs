using UnityEngine;
using UnityEngine.Events;

namespace ChuongCustom
{
    public class SimplePopup : AppPopup
    {
        [SerializeField] private ScreenType _type;

        [SerializeField] public UnityEvent OnOpenAction;

        public override ScreenType GetID() => _type;

        public override void OnOpen()
        {
            base.OnOpen();
            OnOpenAction?.Invoke();
        }
    }
}