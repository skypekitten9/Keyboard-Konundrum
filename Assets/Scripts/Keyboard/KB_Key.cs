using UnityEngine;


public class KB_Key : MonoBehaviour
{
    public void Initialize(GameObject visualPrefab, KeyCode keyCode)
    {
        GameObject visual = Instantiate(visualPrefab, transform.position, Quaternion.identity, transform);
        visual.name = "Visual";


        GameObject logic = new GameObject("Logic", typeof(Rigidbody), typeof(BoxCollider));
        logic.transform.position = transform.position;
        logic.transform.rotation = Quaternion.identity;
        logic.transform.parent = transform;

        logic.GetComponent<Rigidbody>().useGravity = false;
        logic.GetComponent<Rigidbody>().isKinematic = true;
        logic.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.5f, 0.0f);


        this.keyCode = keyCode;
    }


    [SerializeField] private KeyCode keyCode;
    public KeyCode KeyCode { get { return keyCode; } }

}
