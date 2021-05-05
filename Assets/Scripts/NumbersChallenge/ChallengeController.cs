using ConfigurationObjects;
using ConfigurationObjects.Language;
using ScriptableObjectsArchitecture;
using UnityEngine;

namespace NumbersChallenge
{
    public class ChallengeController : MonoBehaviour
    {
        [SerializeField]
        NumberToTextConfiguration _enunciateConfiguration;

        [SerializeField]
        AnswersConfiguration _answerConfiguration;

        [SerializeField]
        ChallengePart _questionPanel;

        [SerializeField]
        ChallengePart _answerPanel;

        [SerializeField]
        IntValue _correctAnswers;

        [SerializeField]
        IntValue _wrongAnswers;

        Challenge CurrentChallenge { get; set; }

        public void Awake()
        {
            StartGame();
        }

        private void StartGame()
        {
            NextChallenge();
        }

        public void NextChallenge()
        {
            CurrentChallenge = new Challenge(_enunciateConfiguration, _answerConfiguration);

            _questionPanel.SetUp(CurrentChallenge);
            _questionPanel.Show();

            _answerPanel.SetUp(CurrentChallenge);
        }
    }
}