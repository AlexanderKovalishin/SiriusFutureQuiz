using SiriusFuture.Quiz.Core.Components;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SiriusFuture.Quiz.Game
{
    public class QuizLetter : MonoBehaviour, 
        IShow, 
        IHide,
        IGetInstanceFromPoolListener,
        IPointerClickHandler
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private QuizLetterAnimator _animator;

        public delegate void ClickDelegate(QuizLetter letter);

        public event ClickDelegate Click;
        public char LetterValue { get; private set; }

        public bool IsVisible { get; private set; }

        public void SetLetter(char letter)
        {
            LetterValue = letter;
            _text.SetText(letter.ToString());
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            Click?.Invoke(this);
        }

        public void Show()
        {
            IsVisible = true;
            _animator.Show();
        }

        public void HideFail()
        {
            IsVisible = false;
            _animator.HideFail();
        }
        
        public void HideSuccess()
        {
            IsVisible = false;
            _animator.HideSuccess();
        }

        public void OnGetInstanceFromPool()
        {
            IsVisible = false;
            _animator.ResetAnimator();
        }

        public void Hide()
        {
            IsVisible = false;
            _animator.Hide();
        }
    }
}