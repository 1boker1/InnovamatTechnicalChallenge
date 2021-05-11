using System.Collections.Generic;
using Challenge;
using ScriptableObjectsArchitecture;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace ChallengeStates
{
    public class AnswerChallengeState : ChallengeState
    {
        [SerializeField]
        private ChallengeOptionUI _answerPrefab;

        [SerializeField]
        private List<ChallengeOptionUI> _answers = new List<ChallengeOptionUI>();

        [SerializeField]
        Fade _fade;
        
        ChallengeOptionUI _correctAnswer;
        
        public override void SetUp(Challenge.Challenge currentChallenge)
        {
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

        public override void OnEnterState()
        {
            CurrentState = this;
            gameObject.SetActive(true);

            _fade.GetFadeIn().Execute();
        }

        public override void OnExitState()
        {
            _fade.GetFadeOut().Execute();
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

        public void OnFailedChoice()
        {
            _correctAnswer.SetColorButton(_correctAnswer.GetCurrentConfiguration().GetRightColor());

            OnExitState();
        }

        public void OnGoodChoice()
        {
            OnExitState();
        }
    }
}