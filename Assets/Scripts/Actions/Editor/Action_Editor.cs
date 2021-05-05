using UnityEditor;


[CustomEditor(typeof(Action))]
public class Action_Editor : Editor
{
    //SerializedProperty interactionType;
    //SerializedProperty valueChangeSpeed;
    //SerializedProperty valueClamp;

    //SerializedProperty timerLength;
    //SerializedProperty tapChangeSpeed;


    void OnEnable()
    {
        //interactionType = serializedObject.FindProperty("interactionType");
        //valueChangeSpeed = serializedObject.FindProperty("valueChangeSpeed");
        //valueClamp = serializedObject.FindProperty("valueClamp");

        //timerLength = serializedObject.FindProperty("timerLength");
        //tapChangeSpeed = serializedObject.FindProperty("tapChangeSpeed");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Action action = target as Action;
        if (action != null)
        {
            //EditorGUILayout.PropertyField(interactionType);
            //EditorGUILayout.PropertyField(valueChangeSpeed);
            //EditorGUILayout.PropertyField(valueClamp);

            //if (action.InteractionType == InteractionType.Timer)
            //    EditorGUILayout.PropertyField(timerLength);

            //if (action.InteractionType == InteractionType.Tap)
            //    EditorGUILayout.PropertyField(tapChangeSpeed);
        }
        //serializedObject.ApplyModifiedProperties();
    }
}
