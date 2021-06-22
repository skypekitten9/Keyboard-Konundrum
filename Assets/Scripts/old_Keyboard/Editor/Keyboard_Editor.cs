//using UnityEngine;
//using UnityEditor;


//[CustomEditor(typeof(Keyboard)), CanEditMultipleObjects]
//public class Keyboard_Editor : Editor
//{
//    SerializedProperty keyBasePrefab;


//    void OnEnable()
//    {
//        keyBasePrefab = serializedObject.FindProperty("keyBasePrefab");
//    }


//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        Keyboard keyboard = target as Keyboard;
//        if (keyboard != null)
//        {        
//            EditorGUILayout.PropertyField(keyBasePrefab);

//            EditorGUILayout.Separator();

//            if (GUILayout.Button("Generate Keyboard"))
//            {
//                keyboard.Generate();
//            }
//        }

//        serializedObject.ApplyModifiedProperties();
//    }

//    protected virtual void OnSceneGUI()
//    {
//        //Keyboard keyboard = target as Keyboard;

//        //if (keyboard != null && keyboard.Keys != null)
//        //{
//        //    for (int i = 0; i < keyboard.Keys.Length; i++)
//        //    {
//        //        Handles.color = Color.red;

//        //        if (Handles.Button(keyboard.Keys[i].transform.position, Quaternion.identity, Gizmos.probeSize, Gizmos.probeSize, Handles.SphereHandleCap))
//        //        {
                    
//        //        }
//        //    }
//        //}

//    }

//}
