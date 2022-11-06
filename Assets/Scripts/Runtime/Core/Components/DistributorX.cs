using System;
using System.Collections.Generic;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class DistributorX: ChildrenTransformProcessor
    {
        [SerializeField] private float _distance = 1f;

        public List<Transform> DistributeChildren()
        {
            var children = CacheChildren();
            Distribute(children);
            return children;
        }
        
        public void Distribute<T>(IList<T> items) where T: Component
        {
            var totalLength = (items.Count - 1) * _distance;
            var position = totalLength * -0.5f;
            foreach (var item in items)
            {
                ApplyItemTransform(item.transform, position);
                position += _distance;
            }
        }

        private void ApplyItemTransform(Transform itemTransform, float position)
        {
            itemTransform.localPosition = itemTransform.localPosition.WithX(position);
        }
    }
}