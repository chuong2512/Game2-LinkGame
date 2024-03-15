using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChuongCustom
{
    [RequireComponent(typeof(Button))]
    public abstract class AButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _button = GetComponent<Button>();
        }
#endif

        private void Start()
        {
            SetListener(OnClickButton);
            OnStart();
        }

        public void SetListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        protected abstract void OnClickButton();
        protected abstract void OnStart();
    }
}