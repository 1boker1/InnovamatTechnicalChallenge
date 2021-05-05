using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ConfigurationObjects
{
    [CreateAssetMenu]
    [Serializable]
    public class ChoiceButtonConfiguration : ScriptableObject
    {
        [SerializeField]
        Color _wrongChoiceColor;

        [SerializeField]
        Color _rightChoiceColor;

        [SerializeField]
        Color _initialColor = Color.white;

        public Color GetWrongColor()
        {
            return _wrongChoiceColor;
        }

        public Color GetRightColor()
        {
            return _rightChoiceColor;
        }

        public Color GetInitialColor()
        {
            return _initialColor;
        }
    }
}