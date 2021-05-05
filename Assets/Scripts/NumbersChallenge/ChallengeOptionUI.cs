using ConfigurationObjects;
using ScriptableObjectsArchitecture;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NumbersChallenge
{
    public class ChallengeOptionUI : MonoBehaviour
    {
        [Header("External Info")]
        [SerializeField]
        IntValue _currentTry;

        [SerializeField]
        IntValue _passedScore;

        [SerializeField]
        IntValue _failedScore;

        [Header("Button Configuration")]
        [SerializeField]
        ChoiceButtonConfiguration _buttonConfiguration;

        [Header("Components")]
        [SerializeField]
        Animation _buttonAnimation;

        [SerializeField]
        AnimationClip _fadeAnimation;

        [SerializeField]
        Image _image;

        [SerializeField]
        Button _button;

        [SerializeField]
        Text _number;

        bool _correct;

        public void SetUpNumber(int number, bool correct)
        {
            SetColorButton(_buttonConfiguration.GetInitialColor());
            _number.color = Color.black;

            _button.interactable = true;
            _number.text = number.ToString();
            _correct = correct;
        }

        public void OnClick()
        {
            if (_correct)
            {
                GoodChoice();
            }
            else
            {
                WrongChoice();
            }
        }

        private void WrongChoice()
        {
            SetColorButton(_buttonConfiguration.GetWrongColor());

            _currentTry.RuntimeValue++;

            if (_currentTry.RuntimeValue >= 2)
            {
                _failedScore.RuntimeValue++;
            }

            PlayAnimationClip(_fadeAnimation);
        }

        private void GoodChoice()
        {
            SetColorButton(_buttonConfiguration.GetRightColor());

            _passedScore.RuntimeValue++;

            PlayAnimationClip(_fadeAnimation);
        }

        public void SetColorButton(Color color)
        {
            _image.color = color;
        }

        private void PlayAnimationClip(AnimationClip clip)
        {
            _buttonAnimation.clip = clip;
            _buttonAnimation.Rewind();
            _buttonAnimation.Play();
        }

        public void Enable(bool enabled)
        {
            gameObject.SetActive(enabled);
        }

        public ChoiceButtonConfiguration GetCurrentConfiguration()
        {
            return _buttonConfiguration;
        }
    }
}