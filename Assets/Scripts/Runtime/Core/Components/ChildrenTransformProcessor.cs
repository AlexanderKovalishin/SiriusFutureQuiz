using System.Collections.Generic;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class ChildrenTransformProcessor : MonoBehaviour
    {
        private readonly List<Transform> _children = new();
        protected List<Transform> CacheChildren()
        {
            _children.Clear();
            var thisTransform = transform;
            for (var i = 0; i < thisTransform.childCount; i++)
            {
                var child = thisTransform.GetChild(i);
                if (!child.gameObject.activeInHierarchy) continue;
                _children.Add(child);
            }

            return _children;
        }
    }
}