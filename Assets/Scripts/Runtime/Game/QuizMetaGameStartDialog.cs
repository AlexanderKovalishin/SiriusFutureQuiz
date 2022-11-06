using SiriusFuture.Quiz.Core;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;
using UnityEngine.UI;

namespace SiriusFuture.Quiz.Game
{
    public class QuizMetaGameStartDialog : Dialog<VoidType, VoidType>
    {
        [SerializeField] private Button _startGameButton;

        protected override void Awake()
        {
            base.Awake();
            _startGameButton.onClick.AddListener(StartGameButtonOnClick);
        }

        private void StartGameButtonOnClick()
        {
            Complete(VoidType.Empty);
        }
    }
}