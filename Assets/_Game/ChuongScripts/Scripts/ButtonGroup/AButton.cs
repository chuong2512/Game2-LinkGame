using System;
using UnityEngine;
using UnityEngine.Events;

namespace TonNgoKhong.Scripts.ButtonGroup
{
    public abstract class AButton : MonoBehaviour
    {
        public abstract void SetListener(UnityAction action);
        public abstract void OnChoose();

        public abstract void OnUnChoose();
    }
}