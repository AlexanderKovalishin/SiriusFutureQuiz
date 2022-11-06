using System.Collections.Generic;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizAnswer : MonoBehaviour
    {
        [SerializeField] private QuizAnswerLetterPool _lettersPool;
        [SerializeField] private DistributorX _distributor;

        private readonly List<QuizAnswerLetter> _letters = new List<QuizAnswerLetter>();

        public void SetAnswer(string answer)
        {
            _lettersPool.ReturnAll();
            _letters.Clear();
            
            foreach (var letterValue in answer)
            {
                var letter = _lettersPool.GetInstance();
                letter.SetLetter(letterValue);
                _letters.Add(letter);
            }
            
            _distributor.Distribute(_letters);
        }
    }
}