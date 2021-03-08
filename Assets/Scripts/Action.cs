using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Action : MonoBehaviour
{
    public bool Activated { get; set; } = false;

    [SerializeField] private float speed;
    [SerializeField] private Vector2 positionClamp;

    private float value;
    private Vector3 startPosition;
    private Rigidbody rb;



    private void Awake()
    {
        startPosition = gameObject.transform.position;
        value = startPosition.y;
        rb = GetComponent<Rigidbody>();
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
