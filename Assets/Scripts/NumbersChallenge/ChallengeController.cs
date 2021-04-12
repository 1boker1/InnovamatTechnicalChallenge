using InnovamatTechnicalChallenge.ConfigurationObjects;
using UnityEngine;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public class ChallengeController : MonoBehaviour
    {
        public NumberToTextConfiguration enunciateConfiguration;
        public AnswersConfiguration answerConfiguration;

        public ChallengePart questionPanel;
        public ChallengePart answerPanel;

        public Challenge CurrentChallenge { get; set; }

        public void StartGame()
        {

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