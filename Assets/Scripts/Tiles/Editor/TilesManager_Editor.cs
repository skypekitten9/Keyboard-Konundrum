using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TilesManager)), CanEditMultipleObjects]
public class TilesManager_Editor : Editor
{

    private (float, float)[] tilePositions = new (float, float)[]
    {
            (-6.77f, 0.45f), (-5.77f, 0.45f), (-4.77f, 0.45f), (-3.77f, 0.45f), (-2.77f, 0.45f), (-1.77f, 0.45f), (-0.77f, 0.45f), (0.23f, 0.45f), (1.23f, 0.45f), (2.23f, 0.45f), (3.23f, 0.45f), (4.23f, 0.45f), (5.23f, 0.45f), (6.64f, 0.45f),
            (-6.46f, -0.40f), (-5.20f, -0.40f), (-4.20f, -0.40f), (-3.20f, -0.40f), (-2.20f, -0.40f), (-1.20f, -0.40f), (-0.20f, -0.40f), (0.80f, -0.40f), (1.80f, -0.40f), (2.80f, -0.40f), (3.80f, -0.40f), (4.80f, -0.40f), (5.80f, -0.40f), (6.76f, -0.85f),
            (-6.32f, -1.25f), (-4.95f, -1.25f), (-3.95f, -1.25f), (-2.95f, -1.25f), (-1.95f, -1.25f), (-0.95f, -1.25f), (0.05f, -1.25f), (1.05f, -1.25f), (2.05f, -1.25f), (3.05f, -1.25f), (4.05f, -1.25f), (5.05f, -1.25f),
            (-6.16f, -2.10f), (-4.55f, -2.10f), (-3.55f, -2.10f), (-2.55f, -2.10f), (-1.55f, -2.10f), (-0.55f, -2.10f), (0.45f, -2.10f), (1.45f, -2.10f), (2.45f, -2.10f), (3.45f, -2.10f), (4.45f, -2.10f), (6.26f, -2.10f),
            (-6.59f, -2.95f), (-4.38f, -2.95f), (-0.37f, -2.95f), (3.61f, -2.95f), (6.97f, -2.95f),
    };



    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        TilesManager tilesManager = target as TilesManager;
        if (tilesManager != null)
        {
            EditorGUILayout.Separator();

            //if (GUILayout.Button("debug positions"))
            //{
            //    string[] positions = tilePositions.Select(a => "(" + string.Format("{0:0.00}", a.Item1 + 0.80f).Replace(',', '.') + "f, " + string.Format("{0:0.00}", a.Item2 - 2.40f).Replace(',', '.') + "f)").ToArray();
            //    Debug.Log(string.Join(", ", positions));
            //}

            if (GUILayout.Button("Regenerate Tiles"))
            {
                if (EditorUtility.DisplayDialog("Regenerate Tiles", "Are you sure you want to regenerate the tiles?\nThis action can not be undone!", "Yes", "Cancel"))
                    tilesManager.Generate(tilePositions);
            }

            if (GUILayout.Button("Reassign Keys"))
            {
                tilesManager.AssignKeycodesToTiles();
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    protected virtual void OnSceneGUI()
    {
        //Keyboard keyboard = target as Keyboard;

        //if (keyboard != null && keyboard.Keys != null)
        //{
        //    for (int i = 0; i < keyboard.Keys.Length; i++)
        //    {
        //        Handles.color = Color.red;

        //        if (Handles.Button(keyboard.Keys[i].transform.position, Quaternion.identity, Gizmos.probeSize, Gizmos.probeSize, Handles.SphereHandleCap))
        //        {

        //        }
        //    }
        //}

    }

}
