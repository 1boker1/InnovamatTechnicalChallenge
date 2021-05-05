using UnityEngine;
using UnityEngine.Serialization;

namespace ConfigurationObjects.Language
{
    public abstract class NumberToTextConfiguration : ScriptableObject
    {
        [FormerlySerializedAs("maxNumber")]
        [SerializeField]int _maxNumber;

        public abstract string GetTextFromNumber(int number);

        protected static int GetPlace(int value, int place)
        {
            return (value % (place * 10) - value % place) / place;
        }

        public int GetMaxNumber()
        {
            return _maxNumber;
        }
    }
}