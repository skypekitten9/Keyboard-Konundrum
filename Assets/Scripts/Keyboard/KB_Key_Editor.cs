using UnityEditor;


[CustomEditor(typeof(KB_Key)), CanEditMultipleObjects]
public class KB_Key_Editor : Editor
{
    SerializedProperty keyCode;


    void OnEnable()
    {
        keyCode = serializedObject.FindProperty("keyCode");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        KB_Key key = target as KB_Key;
        if (key != null)
        {
            EditorGUILayout.PropertyField(keyCode);
        }

        serializedObject.ApplyModifiedProperties();
    }


    protected virtual void OnSceneGUI()
    {
    }

}
