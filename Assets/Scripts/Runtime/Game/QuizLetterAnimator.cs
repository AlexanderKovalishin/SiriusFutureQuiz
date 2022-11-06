using System;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizLetterAnimator : MonoBehaviour
    {
        [SerializeField] private TriggerAnimator _showAnimator;
        [SerializeField] private TriggerAnimator _hideSuccessAnimator;
        [SerializeField] private TriggerAnimator _hideFailAnimator;
        [SerializeField] private TriggerAnimator _hideAnimator;

        public void Show()
        {
            _showAnimator.SetTrigger();
        }
        
        public void HideSuccess()
        {
            _hideSuccessAnimator.SetTrigger();
        }

        public void HideFail()
        {
            _hideFailAnimator.SetTrigger();
        }

        public void Hide()
        {
            _hideAnimator.SetTrigger();
        }
        
        public void ResetAnimator()
        {
            _showAnimator.ResetAnimator();
            _hideSuccessAnimator.ResetAnimator();
            _hideFailAnimator.ResetAnimator();
        }
    }
}