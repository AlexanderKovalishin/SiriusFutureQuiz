using SiriusFuture.Quiz.Core.Components;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizAnswerLetterAnimator: MonoBehaviour
    {
        [SerializeField] private BoolAnimator _showAnimator;
        [SerializeField] private BoolAnimator _openAnimator;

        public void Show()
        {
            _showAnimator.SetValue(true);
        }
        
        public void Hide()
        {
            _showAnimator.SetValue(false);
        }

        public void Open()
        {
            _openAnimator.SetValue(true);
        }

        public void Close()
        {
            _openAnimator.SetValue(false);
        }

        public void ResetAnimator()
        {
            _openAnimator.SetValue(false);
            _showAnimator.SetValue(false);
            _openAnimator.ResetDefaultState();
            _showAnimator.ResetDefaultState();
        }
    }
}