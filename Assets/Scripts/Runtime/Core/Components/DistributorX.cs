using System;
using System.Collections.Generic;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class DistributorX: MonoBehaviour
    {
        [SerializeField] private float _distance = 1f;

        private readonly List<Transform> _children = new();

        public void Distribute()
        {
            CacheChildren();
            var totalLength = (_children.Count - 1) * _distance;
            var position = totalLength * -0.5f;
            foreach (var child in _children)
            {
                child.localPosition = child.localPosition.WithX(position);
                position += _distance;
            }
        }
        
        public void Distribute<T>(IList<T> items) where T: Component
        {
            var totalLength = (items.Count - 1) * _distance;
            var position = totalLength * -0.5f;
            foreach (var item in items)
            {
                var itemTransform = item.transform; 
                itemTransform.localPosition = itemTransform.localPosition.WithX(position);
                position += _distance;
            }
        }
        
        private void CacheChildren()
        {
            _children.Clear();
            var thisTransform = transform;
            for (var i = 0; i < thisTransform.childCount; i++)
            {
                var child = thisTransform.GetChild(i);
                if (!child.gameObject.activeInHierarchy) continue;
                _children.Add(child);
            }
        }
    }
}