using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsArchitecture
{
    public class IntValueListener : MonoBehaviour
    {
        [SerializeField]
        private IntValue _value;

        [SerializeField]
        private UnityEvent _onValueChange;
        private void Awake()
        {
            _value.OnValueChange += ValueUpdated;
        }

        private void OnDestroy()
        {
            _value.OnValueChange -= ValueUpdated;
        }

        private void ValueUpdated()
        {
            _onValueChange?.Invoke();
        }
    }
}