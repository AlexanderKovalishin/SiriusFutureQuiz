using System.Collections.Generic;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class DistributorXY: ChildrenTransformProcessor
    {
        [SerializeField] private float _distanceX = 1f;
        [SerializeField] private float _distanceY = 1f;
        [SerializeField] private int _maxCountPerRow = 10;

        private readonly Queue<Transform> _workQueue = new(); 
        private readonly List<Transform> _workList = new(); 
        public List<Transform> DistributeChildren()
        {
            var children = CacheChildren();
            Distribute(children);
            return children;
        }
        
        public void Distribute<T>(IList<T> items) where T: Component
        {
            foreach (var item in items)
            {
                _workQueue.Enqueue(item.transform);
            }
            
            var rowsCount = items.Count / _maxCountPerRow;
            var rowsModulo = items.Count % _maxCountPerRow;
            if (rowsModulo > 0)
            {
                rowsCount++;
            }
            var totalYLength = (rowsCount - 1) * _distanceY;
            var positionY = totalYLength * 0.5f;
                
            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < _maxCountPerRow; j++)
                {
                    if (_workQueue.Count == 0) break;
                    var item = _workQueue.Dequeue();
                    _workList.Add(item);
                }
                
                var totalXLength = (_workList.Count - 1) * _distanceX;
                var positionX = totalXLength * -0.5f;
                foreach (var item in _workList)
                {
                    ApplyItemTransform(item, positionX, positionY);
                    positionX += _distanceX;
                }

                _workList.Clear();
                positionY -= _distanceY;
            }
            
            _workQueue.Clear();
        }

        private void ApplyItemTransform(Transform itemTransform, float positionX, float positionY)
        {
            itemTransform.localPosition = itemTransform.localPosition.WithXY(positionX, positionY);
        }
    }
}