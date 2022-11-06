using SiriusFuture.Quiz.Core.Components;
using TMPro;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizAnswerLetter: MonoBehaviour, 
        IShow, 
        IHide,
        IGetInstanceFromPoolListener,
        IReturnInstanceToPoolListener
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private QuizAnswerLetterAnimator _animator;
        public char LetterValue { get; private set; }

        public bool IsOpened { get; private set; }

        public void SetLetter(char letterValue)
        {
            LetterValue = letterValue;
            _text.SetText(letterValue.ToString());
        }

        public void Show()
        {
            _animator.Show();
        }
        
        public void Open()
        {
            IsOpened = true;
            _animator.Open();
        }
        
        public void Hide()
        {
            _animator.Hide();
        }

        public void OnGetInstanceFromPool()
        {
        }

        public void OnReturnInstanceToPool()
        {
            IsOpened = false;
            _animator.ResetAnimator();
        }
    }
}