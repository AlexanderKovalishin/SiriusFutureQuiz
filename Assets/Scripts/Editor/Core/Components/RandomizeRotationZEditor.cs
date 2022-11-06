using UnityEditor;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [CustomEditor(typeof(RandomizeRotationZ))]
    public class RandomizeRotationZEditor: ChildrenTransformProcessorEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var rotation = (RandomizeRotationZ)target;
 
            if(GUILayout.Button("Test Rotation Z", GUILayout.Height(40)))
            {
                var children = rotation.ApplyChildren();
                SetItemsDirty(children);
            }
        }
    }
}