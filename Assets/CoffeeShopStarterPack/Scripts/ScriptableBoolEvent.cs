using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Bool Event", menuName = "ScriptableObjects/New Bool Event", order = 0)]
    public class ScriptableBoolEvent : ScriptableObject
    {
        private Action<bool> action;

        public void InvokeAction(bool value)
        {
            action?.Invoke(value);
        }

        public void Subscribe(Action<bool> action)
        {
            this.action += action;
        }

        public void Unsubscribe(Action<bool> action)
        {
            this.action -= action;
        }
    }
}