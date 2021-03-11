using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallRetract_Action : Action
{
    private Rigidbody rb;
    private Vector3 startPosition;


    protected override void Initialize()
    {
        base.Initialize();

        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    protected override void UpdateAction()
    {
        rb.MovePosition(new Vector3(startPosition.x, startPosition.y - value, startPosition.z));
    }
}
