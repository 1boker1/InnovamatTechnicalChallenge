using ConfigurationObjects;
using ConfigurationObjects.Language;
using UnityEngine;

namespace NumbersChallenge
{
    public class Challenge
    {
        public int[] Answers { get; }
        public int CorrectAnswer { get; }
        public string Enunciate { get; }

        public Challenge(NumberToTextConfiguration textConfigurator, AnswersConfiguration answerConfigurator)
        {
            CorrectAnswer = Random.Range(0, textConfigurator.GetMaxNumber());
            Enunciate = textConfigurator.GetTextFromNumber(CorrectAnswer);
            Answers = answerConfigurator.GetRandomPositiveAnswers(CorrectAnswer);
        }
    }
}