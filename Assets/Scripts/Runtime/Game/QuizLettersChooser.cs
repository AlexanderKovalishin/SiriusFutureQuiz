using System;
using System.Collections.Generic;
using SiriusFuture.Quiz.Core.Collections;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizLettersChooser : MonoBehaviour
    {
        [SerializeField] private QuizLetterPool _letterPool;
        [SerializeField] private DistributorXY _distributor;
        [SerializeField] private RandomizeRotationZ _rotation;
        [SerializeField] private QuizLettersChooserAnimator _chooserAnimator;
        [SerializeField] private QuizLettersSortMode _quizLettersSortMode;
        private readonly List<QuizLetter> _letters = new();
        private readonly List<QuizLetter> _hideLetters = new();
        private readonly HashSet<char> _lettersValuesSet = new();
        private readonly HashSet<char> _workLettersValuesSet = new();
        private readonly List<char> _lettersValuesLeftList = new();
        private readonly List<char> _sortedLettersValuesList = new();

        public delegate void ClickLetterDelegate(char letterValue);

        public event ClickLetterDelegate ClickLetter;

        public void CreateLetters(string word, int maxCount)
        {
            CreateLettersInstances(word, maxCount);
            _distributor.Distribute(_letters);
            _rotation.Apply(_letters);
            _chooserAnimator.Show(_letters);
        }
        
        private void LetterOnClick(QuizLetter letter)
        {
            ClickLetter?.Invoke(letter.LetterValue);
        }

        public void FailLetters(char letterValue)
        {
            foreach (var letter in _letters)
            {
                if (letter.LetterValue != letterValue) continue;
                letter.HideFail();
            }
        }
        
        public void SuccessLetters(char letterValue)
        {
            foreach (var letter in _letters)
            {
                if (letter.LetterValue != letterValue) continue;
                letter.HideSuccess();
            }
        }

        private void CreateLettersInstances(string word, int maxCount)
        {
            foreach (var letters in _letters)
            {
                letters.Click -= LetterOnClick;
            }

            _letters.Clear();
            _letterPool.ReturnAll();
            
            for (char c = 'a'; c <= 'z'; c++)
            {
                _lettersValuesSet.Add(c);
            }

            foreach (var c in word)
            {
                if (!_workLettersValuesSet.Contains(c))
                {
                    _workLettersValuesSet.Add(c);
                }

                _lettersValuesSet.Remove(c);
            }

            var currentCount = _workLettersValuesSet.Count;
            _lettersValuesLeftList.AddRange(_lettersValuesSet);
            _lettersValuesLeftList.Shuffle();
            
            var j = 0;
            for (var i = currentCount; i < maxCount && j < _lettersValuesLeftList.Count; i++, j++)
            {
                _workLettersValuesSet.Add(_lettersValuesLeftList[j]);
            }
            
            _sortedLettersValuesList.AddRange(_workLettersValuesSet);
            
            switch (_quizLettersSortMode)
            {
                case QuizLettersSortMode.None:
                    break;
                case QuizLettersSortMode.Alphabet:
                    _sortedLettersValuesList.Sort();
                    break;
                case QuizLettersSortMode.Random:
                    _sortedLettersValuesList.Shuffle();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            

            foreach (var c in _sortedLettersValuesList)
            {
                var letter = _letterPool.GetInstance();
                letter.SetLetter(c);
                letter.Click += LetterOnClick;
                _letters.Add(letter);
            }
            
            _sortedLettersValuesList.Clear();
            _lettersValuesSet.Clear();
            _workLettersValuesSet.Clear();
            _lettersValuesLeftList.Clear();
        }

        public void HideAllLetters()
        {
            _hideLetters.Clear();
            foreach (var letter in _letters)
            {
                if (!letter.IsVisible) continue;
                _hideLetters.Add(letter);
            }
            _chooserAnimator.Hide(_hideLetters);
        }
    }
}