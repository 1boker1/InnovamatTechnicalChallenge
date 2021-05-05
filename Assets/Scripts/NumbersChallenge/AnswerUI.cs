using System.Collections.Generic;
using ScriptableObjectsArchitecture;
using UnityEngine;
using UnityEngine.Events;

namespace NumbersChallenge
{
    public class AnswerUI : ChallengePart
    {
        [SerializeField]
        private ChallengeOptionUI _answerPrefab;

        [SerializeField]
        private List<ChallengeOptionUI> _answers = new List<ChallengeOptionUI>();

        [SerializeField]
        private Animation _canvasAnimation;

        [SerializeField]
        private AnimationClip _fadeInAnimation;

        [SerializeField]
        private AnimationClip _fadeOutAnimation;

        [SerializeField]
        private IntValue _passedScore;

        [SerializeField]
        private IntValue _failedScore;

        [SerializeField]
        private IntValue _currentTries;

        [SerializeField]
        private UnityEvent _onHideAnswers;

        ChallengeOptionUI _correctAnswer;

        private void Awake()
        {
            _failedScore.OnValueChange += OnFailedChoice;
            _passedScore.OnValueChange += OnGoodChoice;
        }

        private void OnDestroy()
        {
            _failedScore.OnValueChange -= OnFailedChoice;
            _passedScore.OnValueChange -= OnGoodChoice;
        }

        public override void SetUp(Challenge currentChallenge)
        {
            _currentTries.RuntimeValue = 0;
            ManageAnswersPrefabList(currentChallenge.Answers.Length);

            for (int i = 0; i < currentChallenge.Answers.Length; i++)
            {
                if (currentChallenge.Answers[i] == currentChallenge.CorrectAnswer)
                {
                    _correctAnswer = _answers[i];
                }

                _answers[i].SetUpNumber(currentChallenge.Answers[i],
                    currentChallenge.Answers[i] == currentChallenge.CorrectAnswer);
            }
        }

        public override void Show()
        {
            _canvasAnimation.clip = _fadeInAnimation;
            _canvasAnimation.Play();
        }

        public override void Hide()
        {
            _canvasAnimation.clip = _fadeOutAnimation;
            _canvasAnimation.Play();
        }

        public void OnHideAnimationEnded()
        {
            _onHideAnswers.Invoke();
        }

        private void ManageAnswersPrefabList(int amount)
        {
            int answerAmountToSpawn = amount - _answers.Count;

            if (answerAmountToSpawn > 0)
            {
                for (int i = 0; i < answerAmountToSpawn; i++)
                {
                    _answers.Add(Instantiate(_answerPrefab, transform));
                }
            }

            for (int i = 0; i < _answers.Count; i++)
            {
                _answers[i].Enable(i < amount);
            }
        }

        private void OnFailedChoice()
        {
            _correctAnswer.SetColorButton(_correctAnswer.GetCurrentConfiguration().GetRightColor());

            Hide();
        }

        private void OnGoodChoice()
        {
            Hide();
        }
    }
}