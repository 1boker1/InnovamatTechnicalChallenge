using ChallengeStates;
using ConfigurationObjects;
using ConfigurationObjects.Language;
using ScriptableObjectsArchitecture;
using UnityEngine;

namespace Challenge
{
    public class ChallengeController : MonoBehaviour
    {
        [Header("Configuration Objects")]
        [SerializeField]
        NumberToTextConfiguration _enunciateConfiguration;

        [SerializeField]
        AnswersConfiguration _answerConfiguration;

        [Header("States")]
        [SerializeField]
        ChallengeState _enunciateState;

        [SerializeField]
        ChallengeState _answerState;

        [Header("Results")]
        [SerializeField]
        IntValue _tries;
        
        global::Challenge.Challenge CurrentChallenge { get; set; }

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
            _tries.RuntimeValue = 0;
            
            CurrentChallenge = new global::Challenge.Challenge(_enunciateConfiguration, _answerConfiguration);

            _enunciateState.SetUp(CurrentChallenge);
            _enunciateState.OnEnterState();

            _answerState.SetUp(CurrentChallenge);
        }
    }
}