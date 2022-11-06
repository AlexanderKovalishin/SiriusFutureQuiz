using System;
using System.Collections.Generic;
using SiriusFuture.Quiz.Core.Collections;
using SiriusFuture.Quiz.Core.Service;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class RandomShowHideAnimator<T> : MonoBehaviour
    {
        [SerializeField] private float _minDelay = 0f;
        [SerializeField] private float _maxDelay = 0.3f;
        
        private Timeline _timeline; // inject

        private readonly List<T> _items = new();
        private void Awake()
        {
            _timeline = ServiceLocator.Locate<Timeline>();
        }

        public void Show(IEnumerable<T> items)
        {
            Run(items, ShowItem);
        }
        
        public void Hide(IEnumerable<T> items)
        {
            Run(items, HideItem);
        }

        private void Run(IEnumerable<T> items, Action<T> action)
        {
            _items.AddRange(items);
            _items.Shuffle();
            for (var i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                var t = (float)i / (_items.Count - 1);
                var delay = Mathf.Lerp(_minDelay, _maxDelay, t);
                _timeline.PosyDelayed(delay, action, item);
            }

            _items.Clear();
        }


        private void ShowItem(T item)
        {
            (item as IShow)?.Show();
        }
        
        private void HideItem(T item)
        {
            (item as IHide)?.Hide();
        }
    }
}