using UnityEngine;
using UnityEditor;


namespace Game
{
    [CustomEditor(typeof(Task)), CanEditMultipleObjects]
    internal sealed class TaskEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var myScript = (Task)target;
            if (GUILayout.Button("Check"))
            {
                myScript.CheckTask();
            }
        }
    }
}
