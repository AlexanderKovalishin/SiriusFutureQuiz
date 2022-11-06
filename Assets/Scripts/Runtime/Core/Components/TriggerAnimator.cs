using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [RequireComponent(typeof(Animator))]
    public class TriggerAnimator: MonoBehaviour
    {
        [SerializeField] private string _triggerName = "Run";
        [SerializeField] private string _defaultState = "Hidden";
        private Animator _animator;
        private int _triggerHash;
        private int _defaultStateHash;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _triggerHash = Animator.StringToHash(_triggerName);
            _defaultStateHash= Animator.StringToHash(_defaultState);
        }

        public void SetTrigger()
        {
            _animator.SetTrigger(_triggerHash);
        }

        public void ResetAnimator()
        {
            _animator.ResetTrigger(_triggerHash);
            _animator.Play(_defaultStateHash);
        }
    }
}