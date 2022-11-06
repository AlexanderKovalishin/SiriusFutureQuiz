using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class ChildrenTransformProcessorEditor: Editor
    {
        protected void SetItemsDirty<T>(IEnumerable<T> items) where T: Component
        {
            foreach (var item in items)
            {
                EditorUtility.SetDirty(item);
            }
        }
    }
}