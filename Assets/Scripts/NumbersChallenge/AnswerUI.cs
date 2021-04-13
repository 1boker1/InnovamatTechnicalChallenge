using InnovamatTechnicalChallenge.SOArchitecture;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public class AnswerUI : ChallengePart
    {
        public ChallengeOptionUI answerPrefab;
        public List<ChallengeOptionUI> answers = new List<ChallengeOptionUI>();

        public Animation canvasAnimation;
        public AnimationClip fadeInAnimation;
        public AnimationClip fadeOutAnimation;

        public IntValue passedScore;
        public IntValue failedScore;
        public IntValue currentTries;
        private ChallengeOptionUI correctAnswer;

        public UnityEvent OnHideAnswers;

        private void OnEnable()
        {
            failedScore.OnValueChange += OnFailedChoice;
            passedScore.OnValueChange += OnGoodChoice;
        }

        public override void SetUp(Challenge currentChallenge)
        {
            currentTries.RuntimeValue=0;
            ManageAnswersPrefabList(currentChallenge.answers.Length);

            for (int i = 0; i < currentChallenge.answers.Length; i++)
            {
                if (currentChallenge.answers[i] == currentChallenge.correctAnswer)
                    correctAnswer = answers[i];

                answers[i].SetUpNumber(currentChallenge.answers[i], currentChallenge.answers[i] == currentChallenge.correctAnswer);
            }
        }

        public override void Show()
        {
            canvasAnimation.clip = fadeInAnimation;
            canvasAnimation.Play();
        }

        public override void Hide()
        {
            canvasAnimation.clip = fadeOutAnimation;
            canvasAnimation.Play();
        }

        public void OnHideAnimationEnded()
        {
            OnHideAnswers.Invoke();
        }

        public void ManageAnswersPrefabList(int Amount)
        {
            int answerAmountToSpawn = Amount - answers.Count;

            if (answerAmountToSpawn > 0)
            {
                for (int i = 0; i < answerAmountToSpawn; i++)
                {
                    answers.Add(Instantiate(answerPrefab, transform));
                }
            }

            for (int i = 0; i < answers.Count; i++)
            {
                answers[i].Enable(i < Amount);
            }
        }

        public void OnFailedChoice()
        {
            correctAnswer.SetColorButton(correctAnswer.buttonConfiguration.goodChoiceColor);

            Hide();
        }

        public void OnGoodChoice()
        {
            Hide();
        }

        private void OnDisable()
        {
            failedScore.OnValueChange -= OnFailedChoice;
            passedScore.OnValueChange -= OnGoodChoice;
        }
    }
}