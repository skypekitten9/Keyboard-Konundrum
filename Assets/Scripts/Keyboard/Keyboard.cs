using UnityEngine;


public class Keyboard : MonoBehaviour
{
    public KB_Key[] Keys { get; private set; }


    private string[] keyCodes = new string[]
    {
        "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "Backslash",
        "Tab", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "[", "]", "Enter",
        "CapsLock", "A", "S", "D", "F", "G", "H", "J", "K", "L", ";", "'",
        "LShift", "Z", "X", "C", "V", "B", "N", "M", ",", ".", "/", "RShift",
        "LCtrl", "Alt", "Space", "AltGr", "RCtrl",
    };

    private (float, float)[] keyPositions = new (float, float)[]
    {
        (-7.57f, 2.85f), (-6.57f, 2.85f), (-5.57f, 2.85f), (-4.57f, 2.85f), (-3.57f, 2.85f), (-2.57f, 2.85f), (-1.57f, 2.85f), (-0.57f, 2.85f), (0.43f, 2.85f), (1.43f, 2.85f), (2.43f, 2.85f), (3.43f, 2.85f), (4.43f, 2.85f), (5.84f, 2.85f),
        (-7.26f, 2.00f), (-6.00f, 2.00f), (-5.00f, 2.00f), (-4.00f, 2.00f), (-3.00f, 2.00f), (-2.00f, 2.00f), (-1.00f, 2.00f), (-0.00f, 2.00f), (1.00f, 2.00f), (2.00f, 2.00f), (3.00f, 2.00f), (4.00f, 2.00f), (5.00f, 2.00f), (5.96f, 1.55f),
        (-7.12f, 1.15f), (-5.75f, 1.15f), (-4.75f, 1.15f), (-3.75f, 1.15f), (-2.75f, 1.15f), (-1.75f, 1.15f), (-0.75f, 1.15f), (0.25f, 1.15f), (1.25f, 1.15f), (2.25f, 1.15f), (3.25f, 1.15f), (4.25f, 1.15f),
        (-6.96f, 0.30f), (-5.35f, 0.30f), (-4.35f, 0.30f), (-3.35f, 0.30f), (-2.35f, 0.30f), (-1.35f, 0.30f), (-0.35f, 0.30f), (0.65f, 0.30f), (1.65f, 0.30f), (2.65f, 0.30f), (3.65f, 0.30f), (5.46f, 0.30f),
        (-7.39f, -0.55f), (-5.18f, -0.55f), (-1.17f, -0.55f), (2.81f, -0.55f), (6.17f, -0.55f),
    };

    [SerializeField] private GameObject keyBasePrefab;



    public void Generate()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            DestroyImmediate(transform.GetChild(i).gameObject);


        Keys = new KB_Key[keyPositions.Length];

        for (int i = 0; i < keyPositions.Length; i++)
        {
            Vector3 pos = new Vector3(keyPositions[i].Item1, 0.0f, keyPositions[i].Item2);

            GameObject go = Instantiate(keyBasePrefab, pos, Quaternion.identity, transform);
            go.name = keyCodes[i];
            Keys[i] = go.AddComponent<KB_Key>();

            Keys[i].Initialize();
        }
    }

}
