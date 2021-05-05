using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectsArchitecture
{
    public class IntValueListenerUI : MonoBehaviour
    {
        [SerializeField]
        private IntValue _value;

        [SerializeField]
        private Text _textValue;

        private void Awake()
        {
            _value.OnValueChange += UpdateText;

            UpdateText();
        }

        private void OnDestroy()
        {
            _value.OnValueChange -= UpdateText;
        }

        private void UpdateText()
        {
            _textValue.text = _value.RuntimeValue.ToString();
        }
    }
}