using UnityEditor;
using UnityEngine;


namespace Game
{
    [CustomEditor(typeof(MultiTask))]
    internal class MultiTaskEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            MultiTask myScript = (MultiTask)target;
            if (GUILayout.Button("CheckTask"))
            {
                myScript.CheckTask();
            }
        }
    }
}