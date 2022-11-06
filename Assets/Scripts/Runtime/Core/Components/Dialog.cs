using System.Threading.Tasks;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [RequireComponent(typeof(BoolAnimator))]
    public class Dialog<TResult, TArgs>: MonoBehaviour
    {
        private BoolAnimator _animator;
        private TaskCompletionSource<TResult> _completion;

        protected virtual void Awake()
        {
            _animator = GetComponent<BoolAnimator>();
        }

        public async ValueTask<TResult> ShowDialog(TArgs args)
        {
            OnShow(args);
            _animator.SetValue(true);
            _completion = new TaskCompletionSource<TResult>();
            var result = await _completion.Task;
            _animator.SetValue(false);
            return result;
        }

        protected virtual void OnShow(TArgs args)
        {
        }

        protected void Complete(TResult result)
        {
            _completion?.SetResult(result);
        }
    }
}