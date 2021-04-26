using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(KB_Key)), CanEditMultipleObjects]
public class KB_Key_Editor : Editor
{
    SerializedProperty keyCode;
    SerializedProperty keyPrefab;


    void OnEnable()
    {
        keyCode = serializedObject.FindProperty("keyCode");
        keyPrefab = serializedObject.FindProperty("keyPrefab");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        KB_Key key = target as KB_Key;
        if (key != null)
        {
            EditorGUILayout.PropertyField(keyCode);
            EditorGUILayout.PropertyField(keyPrefab);

            EditorGUILayout.Separator();

            if (GUILayout.Button("Regenerate Key"))
            {
                foreach (var selected in Selection.gameObjects)
                {
                    KB_Key selectedKey = selected.GetComponent<KB_Key>();
                    if (selectedKey)
                    {
                        selectedKey.Generate();
                    }
                }
            }
        }
        serializedObject.ApplyModifiedProperties();
    }


    protected virtual void OnSceneGUI()
    {
    }

}
