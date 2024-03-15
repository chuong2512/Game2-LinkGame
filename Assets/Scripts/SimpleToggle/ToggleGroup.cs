using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleToggle
{
    public class ToggleGroup : MonoBehaviour
    {
        [SerializeField] private List<SimpleToggle> toggles;

        private void Start()
        {
            foreach (var simpleToggle in toggles)
            {
                simpleToggle.AssignGroup(this);
            }
        }

        public void ActiveToggle(int i)
        {
            if (i >= toggles.Count) return;
            for (var index = 0; index < toggles.Count; index++)
            {
                if (index == i)
                {
                    toggles[i].IsOn = true;
                    continue;
                }
                toggles[index].IsOn = false;
            }
        }

        public void NotifyToggleOn(SimpleToggle toggle)
        {
            for (var index = 0; index < toggles.Count; index++)
            {
                if(toggles[index] == toggle) continue;
                toggles[index].IsOn = false;
            }
        }
    }
}