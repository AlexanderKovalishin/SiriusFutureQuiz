using System;
using SiriusFuture.Quiz.Core.Components;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    [RequireComponent(typeof(BoolAnimator))]
    public class UIBlackout: MonoBehaviour
    {
        private BoolAnimator _animator;
        private UIBlackoutDisposeAction _disposeAction;

        private void Awake()
        {
            _animator = GetComponent<BoolAnimator>();
            _disposeAction = new UIBlackoutDisposeAction(_animator);
        }

        public IDisposable Show()
        {
            _animator.SetValue(true);
            return _disposeAction;
        }

        private class UIBlackoutDisposeAction: IDisposable
        {
            private readonly BoolAnimator _animator;

            public UIBlackoutDisposeAction(BoolAnimator animator)
            {
                _animator = animator;
            }

            public void Dispose()
            {
                _animator.SetValue(false);
            }
        }
    }
}