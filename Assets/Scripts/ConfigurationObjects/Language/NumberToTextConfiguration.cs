using UnityEngine;

namespace InnovamatTechnicalChallenge.ConfigurationObjects
{
    public abstract class NumberToTextConfiguration : ScriptableObject
    {
        public abstract string GetTextFromNumber(int Number);

        public int GetPlace(int value, int place)
        {
            return ((value % (place * 10)) - (value % place)) / place;
        }
    }
}