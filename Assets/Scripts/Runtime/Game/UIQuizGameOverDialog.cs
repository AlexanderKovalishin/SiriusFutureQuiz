using SiriusFuture.Quiz.Core;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;
using UnityEngine.UI;

namespace SiriusFuture.Quiz.Game
{
    public class UIQuizGameOverDialog : Dialog<VoidType, VoidType>
    {
        [SerializeField] private Button _okButton;
        [SerializeField] private AudioSource _clickAudio;
        
        protected override void Awake()
        {
            base.Awake();
            _okButton.onClick.AddListener(OkButtonOnClick);
        }
        private void OkButtonOnClick()
        {
            _clickAudio.Play();
            Complete(VoidType.Empty);
        }
    }
}