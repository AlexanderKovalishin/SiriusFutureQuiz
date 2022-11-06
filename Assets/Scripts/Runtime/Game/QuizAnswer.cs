using System;
using System.Collections.Generic;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizAnswer : MonoBehaviour
    {
        [SerializeField] private QuizAnswerLetterPool _lettersPool;
        [SerializeField] private QuizAnswerAnimator _answerAnimator;
        [SerializeField] private MultiAudio _audio;
        [SerializeField] private DistributorX _distributor;
        [SerializeField] private RandomizeRotationZ _rotation;

        private readonly List<QuizAnswerLetter> _letters = new();
        private float _closedCount;
        
        public void SetAnswer(string answer)
        {
            _closedCount = answer.Length;
            _lettersPool.ReturnAll();
            _letters.Clear();
            
            foreach (var letterValue in answer)
            {
                var letter = _lettersPool.GetInstance();
                letter.SetLetter(letterValue);
                _letters.Add(letter);
            }
            
            _distributor.Distribute(_letters);
            _rotation.Apply(_letters);
            _answerAnimator.Show(_letters);
            _audio.Play();
        }

        public bool IsComplete()
        {
            return _closedCount <= 0;
        }

        public bool OpenLetter(char letterValue)
        {
            var result = false;
            foreach (var letter in _letters)
            {
                if (letter.LetterValue != letterValue) continue;
                result = true;
                letter.Open();
                _closedCount--;
            }

            return result;
        }

        public void HideAllLetters()
        {
            _audio.Play();
            _answerAnimator.Hide(_letters);
        }
    }
}