using SiriusFuture.Quiz.Core;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;
using UnityEngine.UI;

namespace SiriusFuture.Quiz.Game
{
    public class UIQuizGameOverDialog : Dialog<VoidType, VoidType>
    {
        [SerializeField] private Button _okButton;

        protected override void Awake()
        {
            base.Awake();
            _okButton.onClick.AddListener(OkButtonOnClick);
        }
        private void OkButtonOnClick()
        {
            Complete(VoidType.Empty);
        }
    }
}