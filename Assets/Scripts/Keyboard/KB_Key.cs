using UnityEngine;


public class KB_Key : MonoBehaviour
{
    public void Initialize()
    {
        GameObject logic = Instantiate(new GameObject("Logic", typeof(Rigidbody), typeof(BoxCollider)), transform.position, Quaternion.identity, transform);
        logic.GetComponent<Rigidbody>().useGravity = false;
        logic.GetComponent<Rigidbody>().isKinematic = true;
        logic.GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.5f, 0.0f);
        logic.name = "Logic";
    }


    //
}
