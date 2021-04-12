using InnovamatTechnicalChallenge.ConfigurationObjects;
using UnityEngine;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public class Challenge
    {
        public string enunciate;

        public int[] answers;
        public int correctAnswer;

        public Challenge(NumberToTextConfiguration TextConfigurator, AnswersConfiguration AnswerConfigurator)
        {
            correctAnswer = Random.Range(0, TextConfigurator.maxNumber);
            enunciate = TextConfigurator.GetTextFromNumber(correctAnswer);
            answers = AnswerConfigurator.GetRandomPositiveAnswers(correctAnswer);
        }
    }
}