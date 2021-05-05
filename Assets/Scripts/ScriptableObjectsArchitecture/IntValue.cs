using System;
using UnityEngine;

namespace ScriptableObjectsArchitecture
{
    [CreateAssetMenu(fileName = "IntValue")]
    [Serializable]
    public class IntValue : ScriptableObject, ISerializationCallbackReceiver
    {
        public delegate void OnValueChangeDelegate();

        [SerializeField]
        private int _value;

        private int _runtimeValue;

        public int RuntimeValue
        {
            get => _runtimeValue;
            set
            {
                _runtimeValue = value;
                OnValueChange?.Invoke();
            }
        }

        public void OnAfterDeserialize()
        {
            _runtimeValue = _value;
        }

        public void OnBeforeSerialize() { }
        public event OnValueChangeDelegate OnValueChange;
    }
}