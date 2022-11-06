using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [RequireComponent(typeof(Animator))]
    public class BoolAnimator: MonoBehaviour
    {
        [SerializeField] private string _boolParameter = "Visible";
        [SerializeField] private string _defaultState = "Hidden";
        private Animator _animator;
        private int _boolParameterHash;
        private int _defaultStateHash;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _boolParameterHash = Animator.StringToHash(_boolParameter);
            _defaultStateHash= Animator.StringToHash(_defaultState);
        }

        public void SetValue(bool value)
        {
            _animator.SetBool(_boolParameterHash, value);
        }

        public void ResetDefaultState()
        {
            _animator.Play(_defaultStateHash);
        }
    }
}