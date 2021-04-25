using UnityEditor;


[CustomEditor(typeof(KB_Key)), CanEditMultipleObjects]
public class KB_Key_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        KB_Key key = target as KB_Key;
        if (key != null)
        {

        }
    }


    protected virtual void OnSceneGUI()
    {
    }

}
