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

        //if (transform.Find("Logic"))
        //    DestroyImmediate(transform.Find("Logic").gameObject);

        //CreateLogic();
        //CreateVisual();
    }


    //private void CreateLogic()
    //{
    //    GameObject logic = new GameObject("Logic", typeof(Rigidbody), typeof(BoxCollider));
    //    logic.transform.position = transform.position;
    //    logic.transform.rotation = Quaternion.identity;
    //    logic.transform.parent = transform;

    //    logic.GetComponent<Rigidbody>().useGravity = false;
    //    logic.GetComponent<Rigidbody>().isKinematic = true;
    //    logic.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.5f, 0.0f);
    //}

    //private void CreateVisual()
    //{


    //}


}
