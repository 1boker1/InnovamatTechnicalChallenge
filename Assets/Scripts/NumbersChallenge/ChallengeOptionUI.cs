using InnovamatTechnicalChallenge.ConfigurationObjects;
using InnovamatTechnicalChallenge.SOArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public class ChallengeOptionUI : MonoBehaviour
    {
        [Header("External Info")]
        public IntValue currentTry;

        public IntValue passedScore;
        public IntValue failedScore;

        [Header("Button Configuration")]
        public ChoiceButtonConfiguration m_ButtonConfiguration;

        [Header("Button Components")]
        public Button button;
        public Text number;
        private bool correct;

        public void SetUpNumber(int _Number, bool _Correct)
        {
            number.text = _Number.ToString();
            correct = _Correct;
        }

        public void OnClick()
        {
            if(correct)
                GoodChoice();
            else
                WrongChoice();
        }

        void WrongChoice()
        {

        }

        void GoodChoice()
        {

        }

        public void Enable(bool enabled)
        {
            gameObject.SetActive(enabled);
        }
    }
}