using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Action : MonoBehaviour
{
    public bool Activated { get; set; } = false;

    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float maxHeight = 3.0f;

    private Vector3 startPosition;
    private Rigidbody rb;

    private float value;
    private Vector2 positionClamp;




    private void Awake()
    {
        startPosition = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();

        value = startPosition.y;
        positionClamp = new Vector2(value, value + maxHeight);
    }


    private void Update()
    {
        if (Activated)
        {
            value = Mathf.Clamp(value += Time.deltaTime * speed, positionClamp.x, positionClamp.y);
        }
        else
        {
            value = Mathf.Clamp(value -= Time.deltaTime * speed, positionClamp.x, positionClamp.y);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(new Vector3(startPosition.x, value, startPosition.z));
    }
}
