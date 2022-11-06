using UnityEditor;
using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [CustomEditor(typeof(DistributorX))]
    public class DistributorXEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var distributor = (DistributorX)target;
 
            if(GUILayout.Button("Test Distribute", GUILayout.Height(40)))
            {
                distributor.Distribute();
                
                var transform = distributor.transform;
                for (var i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);
                    EditorUtility.SetDirty(child);
                }
            }
         
        }
    }
}