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
        [SerializeField] private TriggerAnimator _intro;

        protected override void Awake()
        {
            base.Awake();
            _startGameButton.onClick.AddListener(StartGameButtonOnClick);
        }

        protected override void OnShow(VoidType args)
        {
            base.OnShow(args);
            _intro.ResetAnimator();
        }

        private void StartGameButtonOnClick()
        {
            _clickAudio.Play();
            Complete(VoidType.Empty);
        }
    }
}