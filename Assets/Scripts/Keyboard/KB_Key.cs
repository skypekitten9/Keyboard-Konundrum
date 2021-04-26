using UnityEngine;


[SelectionBase]
public class KB_Key : MonoBehaviour
{
    public void Initialize(GameObject keyPrefab, KeyCode keyCode)
    {
        this.keyCode = keyCode;
        this.keyPrefab = keyPrefab;


        Instantiate(keyPrefab, transform.position, Quaternion.identity, transform).name = "Key";
    }


    [SerializeField] private KeyCode keyCode;
    public KeyCode KeyCode { get { return keyCode; } }

    [SerializeField] private GameObject keyPrefab;




    public void Generate()
    {
        if (transform.childCount > 0)
            DestroyImmediate(transform.GetChild(0).gameObject);

        Instantiate(keyPrefab, transform.position, Quaternion.identity, transform).name = "Key";
    }

}
