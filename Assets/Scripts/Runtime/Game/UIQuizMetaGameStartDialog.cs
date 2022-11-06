using SiriusFuture.Quiz.Core;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;
using UnityEngine.UI;

namespace SiriusFuture.Quiz.Game
{
    public class UIQuizMetaGameStartDialog : Dialog<VoidType, VoidType>
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private AudioSource _clickAudio;

        protected override void Awake()
        {
            base.Awake();
            _startGameButton.onClick.AddListener(StartGameButtonOnClick);
        }

        private void StartGameButtonOnClick()
        {
            _clickAudio.Play();
            Complete(VoidType.Empty);
        }
    }
}