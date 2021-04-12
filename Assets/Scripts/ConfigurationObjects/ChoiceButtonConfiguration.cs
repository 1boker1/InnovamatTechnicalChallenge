using System;
using UnityEngine;

namespace InnovamatTechnicalChallenge.ConfigurationObjects
{
    [CreateAssetMenu]
    [Serializable]
    public class ChoiceButtonConfiguration : ScriptableObject
    {
        public Color wrongChoiceColor;
        public Color goodChoiceColor;

        public AnimationClip fadeAnimationClip;
    }
}