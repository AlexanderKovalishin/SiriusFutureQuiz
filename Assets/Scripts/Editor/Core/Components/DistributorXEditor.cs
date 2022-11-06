using UnityEditor;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [CustomEditor(typeof(DistributorX))]
    public class DistributorXEditor: ChildrenTransformProcessorEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var distributor = (DistributorX)target;
 
            if(GUILayout.Button("Test Distribute X", GUILayout.Height(40)))
            {
                var children = distributor.DistributeChildren();
                SetItemsDirty(children);
            }
         
        }
    }
}