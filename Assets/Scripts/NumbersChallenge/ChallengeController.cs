using InnovamatTechnicalChallenge.ConfigurationObjects;
using InnovamatTechnicalChallenge.SOArchitecture;
using UnityEngine;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public class ChallengeController : MonoBehaviour
    {
        public NumberToTextConfiguration enunciateConfiguration;
        public AnswersConfiguration answerConfiguration;

        public ChallengePart questionPanel;
        public ChallengePart answerPanel;

        public IntValue correctAnswers;
        public IntValue wrongAnswers;

        public Challenge CurrentChallenge { get; set; }

        private void Start()
        {
            StartGame();
        }
        public void StartGame()
        {
            NextChallenge();
        }
        public void NextChallenge()
        {
            CurrentChallenge=new Challenge(enunciateConfiguration, answerConfiguration);

            questionPanel.SetUp(CurrentChallenge);
            questionPanel.Show();

            answerPanel.SetUp(CurrentChallenge);
        }
    }
}