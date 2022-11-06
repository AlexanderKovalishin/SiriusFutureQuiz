using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [RequireComponent(typeof(Animator))]
    public class BoolAnimator: MonoBehaviour
    {
        [SerializeField] private string _boolParameter = "Visible";
        private Animator _animator;
        private int _boolParameterHash;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _boolParameterHash = Animator.StringToHash(_boolParameter);
        }

        public void SetVisible(bool value)
        {
            _animator.SetBool(_boolParameterHash, value);
        }
    }
}