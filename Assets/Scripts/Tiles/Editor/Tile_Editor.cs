using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Tile)), CanEditMultipleObjects]
public class Tile_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Tile tile = target as Tile;
        if (tile != null)
        {
            if (GUILayout.Button("Set Tile"))
            {
                foreach (var s in Selection.gameObjects)
                {
                    Tile selectedTile = s.GetComponent<Tile>();
                    if (selectedTile != null)
                        selectedTile.SetTile();
                }

            }
        }
    }

}
