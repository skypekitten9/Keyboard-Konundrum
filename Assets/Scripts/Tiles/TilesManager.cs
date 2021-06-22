using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TilesManager : Singleton<TilesManager>
{
    public Tile[] Tiles { get; private set; }

    [SerializeField] private GameObject tileBasePrefab;
    [SerializeField] private GameObject debug_tileReference;


    private string[] tileNames = new string[]
    {
        "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "Backslash",
        "Tab", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "[", "]", "Return",
        "Caps Lock", "A", "S", "D", "F", "G", "H", "J", "K", "L", ";", "'",
        "LShift", "Z", "X", "C", "V", "B", "N", "M", ",", ".", "/", "RShift",
        "LCtrl", "Alt", "Space", "AltGr", "RCtrl",
    };

    private KeyCode[] keyCodes = new KeyCode[]
    {
        KeyCode.BackQuote, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.Minus, KeyCode.Equals, KeyCode.Backspace,
        KeyCode.Tab, KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.LeftBracket, KeyCode.RightBracket, KeyCode.Return,
        KeyCode.CapsLock, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon, KeyCode.Quote,
        KeyCode.LeftShift, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.Comma, KeyCode.Period, KeyCode.Slash, KeyCode.RightShift,
        KeyCode.LeftControl, KeyCode.LeftAlt, KeyCode.Space, KeyCode.AltGr, KeyCode.RightControl,
    };



    private void Awake()
    {
        AssignKeycodesToTiles();
    }


    public void AssignKeycodesToTiles()
    {
        int[] rowsKeysCounts = new int[] { 14, 14, 12, 12, 5 };
        int keysSum = rowsKeysCounts.Sum();

        Transform[] tileObjects = this.GetComponentsInChildren<Tile>().Select(x => x.transform).ToArray();
        tileObjects = tileObjects.OrderBy(t => -t.position.z).ToArray();


        int[] tilesDivisions = new int[rowsKeysCounts.Length];
        for (int i = 0; i < tilesDivisions.Length; i++)
            tilesDivisions[i] = Mathf.FloorToInt((float)rowsKeysCounts[i] / keysSum * tileObjects.Length);

        int remainingTiles = tileObjects.Length - tilesDivisions.Sum();
        for (int i = 0; i < remainingTiles; i++)
            ++tilesDivisions[i % 5];


        Transform[][] tileObjectsByRow = new Transform[tilesDivisions.Length][];
        for (int i = 0, c = 0; i < tileObjectsByRow.Length; i++)
        {
            tileObjectsByRow[i] = new Transform[tilesDivisions[i]];
            for (int j = 0; j < tileObjectsByRow[i].Length; j++, c++)
            {
                tileObjectsByRow[i][j] = tileObjects[c];
            }
            tileObjectsByRow[i] = tileObjectsByRow[i].OrderBy(t => t.position.x).ToArray();
        }


        Tiles = new Tile[tileObjects.Length];

        int padding = 0;
        for (int i = 0, c = 0; i < tileObjectsByRow.Length; i++)
        {
            for (int j = 0; j < tileObjectsByRow[i].Length; j++, c++)
            {
                Tiles[c] = tileObjectsByRow[i][j].GetComponent<Tile>();
                Tiles[c].Initialize(keyCodes[c + padding], tileNames[c + padding]);

                /*Temp*/
                Tiles[c].SetTile(debug_tileReference);
            }
            padding += rowsKeysCounts[i] - tileObjectsByRow[i].Length;
        }
    }



    public void Generate((float, float)[] tilePositions)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            DestroyImmediate(transform.GetChild(i).gameObject);

        for (int i = 0; i < tilePositions.Length; i++)
            Instantiate(tileBasePrefab, new Vector3(tilePositions[i].Item1, 0.0f, tilePositions[i].Item2), Quaternion.identity, this.transform);

        AssignKeycodesToTiles();
    }

}
