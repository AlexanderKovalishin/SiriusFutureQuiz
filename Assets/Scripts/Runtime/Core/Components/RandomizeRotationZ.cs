using System.Collections.Generic;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class RandomizeRotationZ: ChildrenTransformProcessor
    {
        [SerializeField] private float _minRotation = -10f;
        [SerializeField] private float _maxRotation = 10f;


        public List<Transform> ApplyChildren()
        {
            var children = CacheChildren();
            Apply(children);
            return children;
        }
        
        public void Apply<T>(IList<T> items) where T: Component
        {
            foreach (var item in items)
            {
                ApplyItemTransform(item.transform);
            }
        }

        private void ApplyItemTransform(Transform itemTransform)
        {
            itemTransform.localRotation = Quaternion.Euler(0, 0, Random.Range(_minRotation, _maxRotation));
        }

    }
}