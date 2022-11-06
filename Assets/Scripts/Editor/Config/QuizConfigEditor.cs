using UnityEditor;
using UnityEngine;

namespace SiriusFuture.Quiz.Config
{
    [CustomEditor(typeof(QuizConfig))]
    public class QuizConfigEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var config = (QuizConfig)target;
 
            if(GUILayout.Button("Test Parse", GUILayout.Height(40)))
            {
                config.TestParse();
            }
         
        }
    }
}