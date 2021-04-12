using System.Collections.Generic;
using UnityEngine;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public class AnswerUI : ChallengePart
    {
        public ChallengeOptionUI answerPrefab;
        public List<ChallengeOptionUI> answers = new List<ChallengeOptionUI>();

        public Animation canvasAnimation;
        public AnimationClip fadeInAnimation;
        public AnimationClip fadeOutAnimation;

        public override void SetUp(Challenge currentChallenge)
        {
            ManageAnswersPrefabList(currentChallenge.answers.Length);

            for (int i = 0; i < currentChallenge.answers.Length; i++)
            {
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
    }
}