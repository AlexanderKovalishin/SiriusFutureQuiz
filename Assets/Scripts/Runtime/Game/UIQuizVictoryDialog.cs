using SiriusFuture.Quiz.Core;
using SiriusFuture.Quiz.Core.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SiriusFuture.Quiz.Game
{
    public class UIQuizVictoryDialog : Dialog<VoidType, QuizGameStatistics>
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private string _scoreFormat = "Score: {0}";
        [SerializeField] private Button _okButton;
        [SerializeField] private AudioSource _clickAudio;

        protected override void Awake()
        {
            base.Awake();
            _okButton.onClick.AddListener(OkButtonOnClick);
        }

        protected override void OnShow(QuizGameStatistics args)
        {
            base.OnShow(args);
            _scoreText.SetText(string.Format(_scoreFormat, args.Score));
        }

        private void OkButtonOnClick()
        {
            _clickAudio.Play();
            Complete(VoidType.Empty);
        }
    }
}