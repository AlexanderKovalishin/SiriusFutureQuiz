using UnityEditor;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [CustomEditor(typeof(DistributorXY))]
    public class DistributorXYEditor : ChildrenTransformProcessorEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var distributor = (DistributorXY)target;
 
            if(GUILayout.Button("Test Distribute XY", GUILayout.Height(40)))
            {
                var children = distributor.DistributeChildren();
                SetItemsDirty(children);
            }
         
        }
    }
}