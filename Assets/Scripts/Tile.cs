using UnityEngine;


public class Tile : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    public KeyCode Key { get { return key; } }
}
