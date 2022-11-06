using System;
using System.Collections.Generic;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Service
{
    public class Timeline : MonoBehaviour
    {
        private readonly HashSet<TimelineAction> _actions = new();
        private readonly List<TimelineAction> _currentFrameActions = new();

        public void PosyDelayed<TArgs>(float delay, Action<TArgs> action, TArgs args)
        {
            _actions.Add(new TimelineAction<TArgs>(delay, action, args));
        }

        private void Update()
        {
            _currentFrameActions.Clear();
            foreach (var action in _actions)
            {
                action.Update();
                if (!action.IsExpired) continue;
                _currentFrameActions.Add(action);
            }

            _currentFrameActions.Sort(TimelineActionComparison);
            
            foreach (var action in _currentFrameActions)
            {
                _actions.Remove(action);
                action.Invoke();
            }
        }

        private int TimelineActionComparison(TimelineAction x, TimelineAction y)
        {
            if (x.TimeLeft < y.TimeLeft)
                return -1;
            if (x.TimeLeft > y.TimeLeft)
                return 1;
            return 0;
        }

        private abstract class TimelineAction
        {
            private float _delay;

            public float TimeLeft => _delay;
            public bool IsExpired => _delay <= 0f;

            protected TimelineAction(float delay)
            {
                _delay = delay;
            }

            public void Update()
            {
                _delay -= Time.deltaTime;
            }

            public abstract void Invoke();
        }
        
        private class TimelineAction<TArgs>: TimelineAction
        {
            private readonly Action<TArgs> _action;
            private readonly TArgs _args;
           
            
            public override void Invoke()
            {
                _action?.Invoke(_args);
            }

            public TimelineAction(float delay, Action<TArgs> action, TArgs args) : base(delay)
            {
                _action = action;
                _args = args;
            }
        }

    }
}