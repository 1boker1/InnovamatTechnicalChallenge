using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InnovamatTechnicalChallenge.ConfigurationObjects
{
    [CreateAssetMenu]
    [Serializable]
    public class AnswersConfiguration : ScriptableObject
    {
        public int amountOfAnswers;
        [Min(2)]
        public int maxDifferenceToAnswer;

        public int[] GetRandomPositiveAnswers(int correctAnswer)
        {
            int[] _Results = new int[amountOfAnswers];

            int _IndexToEnterCorrectAnswer = UnityEngine.Random.Range(0, amountOfAnswers);

            _Results[_IndexToEnterCorrectAnswer]=correctAnswer;

            for (int i = 0; i < amountOfAnswers; i++)
            {
                if(i!=_IndexToEnterCorrectAnswer)
                    _Results[i]=(GetRandomNumberExcept(correctAnswer - maxDifferenceToAnswer, correctAnswer + maxDifferenceToAnswer, _Results));
            }

            return _Results;
        }

        private int GetRandomNumberExcept(int min, int max, int[] exceptions)
        {
            int _RandomNumber = UnityEngine.Random.Range(min, max + 1);     //+1 becase of [inclusive] / [exclusive] random function

            while (exceptions.Contains(_RandomNumber))
            {
                _RandomNumber = UnityEngine.Random.Range(min, max + 1);
            }

            return _RandomNumber;
        }
    }
}