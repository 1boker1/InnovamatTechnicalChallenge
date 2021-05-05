using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace ConfigurationObjects
{
    [CreateAssetMenu]
    [Serializable]
    public class AnswersConfiguration : ScriptableObject
    {
        [SerializeField]
        int _amountOfAnswers;

        [Min(2)]
        [SerializeField]
        int _maxDifferenceToAnswer;

        public int[] GetRandomPositiveAnswers(int correctAnswer)
        {
            int[] results = new int[_amountOfAnswers];

            int indexToEnterCorrectAnswer = Random.Range(0, _amountOfAnswers);

            results[indexToEnterCorrectAnswer] = correctAnswer;

            for (int i = 0; i < _amountOfAnswers; i++)
            {
                if (i != indexToEnterCorrectAnswer)
                {
                    results[i] = GetRandomNumberExcept(correctAnswer - _maxDifferenceToAnswer,
                        correctAnswer + _maxDifferenceToAnswer, results);
                }
            }

            return results;
        }

        private int GetRandomNumberExcept(int min, int max, int[] exceptions)
        {
            int randomNumber = Random.Range(min, max + 1); //+1 because of [inclusive] / [exclusive] random function

            while (exceptions.Contains(randomNumber))
            {
                randomNumber = Random.Range(min, max + 1);
            }

            return randomNumber;
        }
    }
}