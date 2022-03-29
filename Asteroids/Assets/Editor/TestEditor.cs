using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Test))]
    public class TestEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var script = (Test)target;

            //if (GUILayout.Button("Rotate around point"))
                
        }
    }
}