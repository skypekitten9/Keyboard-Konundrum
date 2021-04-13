using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float turnSpeed = 3.0f;
    [SerializeField] private float ragdollLaunchMagnitude = 1.0f;

    private Vector3 movement = Vector3.zero;

    private Rigidbody ragdollRigidbody;
    private Transform ragdollHipsTransform;
    private Rigidbody ragdollHipsRigidbody;

    private Animator animator;

    const float TARGET_DISTANCE_TO_GROUND = 0.16f;
    private float fallHeight = 1.5f;


    [SerializeField] private LayerMask groundMask;

    private bool ragdollMode = false;
    private bool canChangeMode = true;


    CopyJoint[] copyJoints;



    private void Awake()
    {
        ragdollRigidbody = GetComponent<Rigidbody>();
        ragdollHipsTransform = transform.GetChild(2).transform;
        ragdollHipsRigidbody = ragdollHipsTransform.GetComponent<Rigidbody>();
        animator = transform.parent.GetComponentInChildren<Animator>();

        copyJoints = GetComponentsInChildren<CopyJoint>();
    }


    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //    StartCoroutine(ToggleRagdollMode());

        movement.x = -Input.GetAxisRaw("Vertical");
        movement.z = Input.GetAxisRaw("Horizontal");
        movement.Normalize();

        if (Input.GetKeyDown(KeyCode.Keypad0) && ragdollMode == false)
        {
            RagdollLaunch();
        }
    }


    private void FixedUpdate()
    {
        if (ragdollMode == false && canChangeMode == true)    //enable ragdoll
        {
            if (ragdollHipsRigidbody.velocity.y > 3.0f || transform.position.y - GetGroundTargetHeight() >= fallHeight)
            {
                StartCoroutine(ToggleRagdollMode(0.0f, 2.0f));
                return;
            }
        }
        else if (ragdollMode == true && canChangeMode == true && IsGrounded())      //get up from ground
        {
            StartCoroutine(ToggleRagdollMode(1.0f, 2.0f));
            return;
        }

        //Debug.Log($"Ragdoll vel_y= {ragdollHipsRigidbody.velocity.y}");


        if (ragdollMode == false)
        {
            PerformRotation();
            PerformMovement();
        }
    }


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
            //animator.SetFloat("Velocity X", 0.0f);
            //animator.SetFloat("Velocity Z", 0.0f);
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
        if (Physics.Raycast(new Ray(ragdollHipsTransform.position, Vector3.down), out hit, fallHeight * 2, groundMask))
        {
            return hit.point.y + TARGET_DISTANCE_TO_GROUND;
        }

        return -fallHeight;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(new Ray(ragdollHipsTransform.position, Vector3.down), 0.4f, groundMask);
    }


    private IEnumerator ToggleRagdollMode(float delayBefore = 0.0f, float delayAfter = 0.0f)
    {
        canChangeMode = false;
        yield return new WaitForSeconds(delayBefore);

        if (ragdollMode && IsGrounded() == false)
        {
            yield return new WaitForSeconds(delayAfter);
            canChangeMode = true;
            yield break;
        }

        ragdollMode = !ragdollMode;
        ragdollRigidbody.isKinematic = !ragdollMode;
        animator.enabled = !ragdollMode;

        foreach (CopyJoint cj in copyJoints)
        {
            cj.ToggleJointMotion();
        }

        yield return new WaitForSeconds(delayAfter);
        canChangeMode = true;
    }


    private void RagdollLaunch()
    {
        Vector3 launchDirection = (movement + Vector3.up).normalized;
        Vector3 launchForce = ragdollLaunchMagnitude * launchDirection;
        ragdollRigidbody.AddForce(launchForce, ForceMode.Acceleration);
    }

}
