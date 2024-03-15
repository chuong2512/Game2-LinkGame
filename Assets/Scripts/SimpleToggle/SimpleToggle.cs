using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleToggle
{
    public class SimpleToggle : MonoBehaviour, IToggle, IPointerClickHandler
    {
        [SerializeField] private GameObject active, disable;
        [SerializeField] private bool isOn;
        private ToggleGroup _toggleGroup;

        public bool IsOn
        {
            get => isOn;
            set
            {
                isOn = value;
                Set(value);
            }
        }

        private void Start()
        {
            Set(isOn);
        }

        public void AssignGroup(ToggleGroup toggleGroup)
        {
            _toggleGroup = toggleGroup;
        }
        
        private void Set(bool isActive)
        {
            active.SetActive(isActive);
            disable.SetActive(!isActive);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick();
        }

        public void Active()
        {
            IsOn = true;
            // ReSharper disable once Unity.NoNullPropagation
            _toggleGroup?.NotifyToggleOn(this);
        }

        public void OnClick()
        {
            if (isOn) return;
            Active();
        }
    }


    public interface IToggle
    {
        bool IsOn { get; set; }
        void AssignGroup(ToggleGroup toggleGroup);
    }
}