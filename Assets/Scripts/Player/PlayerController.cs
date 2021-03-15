#define DEBUG
//#undef DEBUG

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float turnSpeed = 3.0f;

    private Vector3 movement = Vector3.zero;

    private Rigidbody ragdollRigidbody;
    private Transform ragdollHipsTransform;
    private Animator animator;

    const float TARGET_DISTANCE_TO_GROUND = 0.16f;

    [SerializeField] private LayerMask groundMask;


    private bool ragdollMode = false;


    private void Awake()
    {
        ragdollRigidbody = GetComponent<Rigidbody>();
        ragdollHipsTransform = transform.GetChild(2).transform;
        animator = transform.parent.GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            ToggleRagdollMode();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }


    private void FixedUpdate()
    {
        if (ragdollMode == false)
        {
            PerformRotation();
            PerformMovement();
        }

#if DEBUG
        Debug.Log($"Ragdoll vel= {ragdollRigidbody.velocity.magnitude}");
#endif
    }



    /*private IEnumerator ToggleRagdollPhysics()
    {
        ragdollEnabled = !ragdollEnabled;
        ragdollRigidbody.isKinematic = !ragdollEnabled;
        animator.enabled = !ragdollEnabled;

        if (!ragdollEnabled)
        {
            Vector3 playerPos = transform.position;
            Vector3 playerTargetPos = ragdollhipsTransform.position;

            Vector3 ragdollPos = ragdollTransform.localPosition;
            Vector3 ragdollTargetPos = Vector3.zero;

            Quaternion ragdollRot = ragdollTransform.rotation;
            Quaternion ragdollTargetRot = gameObject.transform.rotation;


            int frames = 60;
            for (float i = 1; i <= frames; i++)
            {
                transform.position = Vector3.Lerp(playerPos, playerTargetPos, i / frames);
                ragdollTransform.localPosition = Vector3.Lerp(ragdollPos, ragdollTargetPos, i / frames);
                ragdollTransform.rotation = Quaternion.Lerp(ragdollRot, ragdollTargetRot, i / frames);
                yield return new WaitForFixedUpdate();
            }

            transform.position = playerTargetPos;
            ragdollTransform.localPosition = ragdollTargetPos;
            ragdollTransform.rotation = ragdollTargetRot;
        }
    }*/


    private void PerformMovement()
    {
        Vector3 newPosition = ragdollRigidbody.position + movement * maxSpeed * Time.deltaTime;
        Vector3 groundCorrectedPosition = new Vector3(newPosition.x, GetGroundTargetHeight(), newPosition.z);

        if (Physics.CheckSphere(groundCorrectedPosition, 0.01f, groundMask) == false)   //Checks if the desired move position lies within a collider or not
        {
            ragdollRigidbody.MovePosition(groundCorrectedPosition);

            animator.SetFloat("Velocity X", movement.x);    //Set animation properties
            animator.SetFloat("Velocity Z", movement.z);
        }
        else
        {
            //Stops the walking animation when walking into walls.
            // OBS: This feature is optional!
            animator.SetFloat("Velocity X", 0.0f);
            animator.SetFloat("Velocity Z", 0.0f);
        }
    }

    private void PerformRotation()
    {
        float xRot = movement.z * 8.0f;
        float yRot = movement.x * 70.0f;

        ragdollRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(xRot, yRot, 0), turnSpeed));
    }

    private float GetGroundTargetHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(ragdollHipsTransform.position, Vector3.down), out hit, Mathf.Infinity, groundMask))
        {
            return hit.point.y + TARGET_DISTANCE_TO_GROUND;
        }

        return float.MaxValue;
    }


    private void ToggleRagdollMode()
    {
        ragdollMode = !ragdollMode;
        ragdollRigidbody.isKinematic = !ragdollMode;
        animator.enabled = !ragdollMode;
    }

}
