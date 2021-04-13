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
        public ChoiceButtonConfiguration buttonConfiguration;

        [Header("Button Components")]
        public Animation buttonAnimation;
        public AnimationClip fadeAnimation;

        public Image image;
        public Button button;
        public Text number;
        private bool correct;

        public void SetUpNumber(int _Number, bool _Correct)
        {
            SetColorButton(buttonConfiguration.initialColor);
            number.color=Color.black;

            button.interactable=true;
            number.text = _Number.ToString();
            correct = _Correct;
        }

        public void OnClick()
        {
            if (correct)
                GoodChoice();
            else
                WrongChoice();
        }

        private void WrongChoice()
        {
            SetColorButton(buttonConfiguration.wrongChoiceColor);

            currentTry.RuntimeValue++;

            if (currentTry.RuntimeValue >= 2)
            {
                failedScore.RuntimeValue++;
            }

            PlayAnimationClip(fadeAnimation);
        }

        private void GoodChoice()
        {
            SetColorButton(buttonConfiguration.goodChoiceColor);

            passedScore.RuntimeValue++;

            PlayAnimationClip(fadeAnimation);
        }

        public void SetColorButton(Color color)
        {
            image.color = color;
        }

        private void PlayAnimationClip(AnimationClip Clip)
        {
            buttonAnimation.clip = Clip;
            buttonAnimation.Rewind();
            buttonAnimation.Play();
        }

        public void Enable(bool enabled)
        {
            gameObject.SetActive(enabled);
        }
    }
}