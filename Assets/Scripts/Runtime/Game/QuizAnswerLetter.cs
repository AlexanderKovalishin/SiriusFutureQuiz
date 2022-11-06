using TMPro;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizAnswerLetter: MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        public void SetLetter(char letterValue)
        {
            _text.SetText(letterValue.ToString());
        }
    }
}