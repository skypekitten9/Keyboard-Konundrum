using RagdollMecanimMixer;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float turnSpeed = 3.0f;

    private Vector3 movement = Vector3.zero;
    public float MoveSpeed { get { return movement.magnitude * maxSpeed; } } // [0,1]

    private Transform playerTransform;
    private Rigidbody playerRigidbody;
    private RamecanMixer ramecanMixer;

    const float TARGET_DISTANCE_TO_GROUND = 0.08f;

    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private LayerMask groundMask;


    private bool dead = false;  //temp



    private void Awake()
    {
        playerTransform = transform.GetChild(0).transform;
        playerRigidbody = GetComponentInChildren<Rigidbody>();
        ramecanMixer = GetComponentInChildren<RamecanMixer>();
    }


    private void Update()
    {
        movement.x = -Input.GetAxisRaw("Vertical");
        movement.z = Input.GetAxisRaw("Horizontal");
        movement.Normalize();

        /*TEMP*/ //toggle die/revive
        if (Input.GetKeyDown(KeyCode.Q))
        {
            string newState = dead ? "default" : "dead";

            ramecanMixer.BeginStateTransition(newState);
            playerRigidbody.isKinematic = !dead;
            dead = !dead;
        }
    }


    private void FixedUpdate()
    {
        PerformMovement();
        PerformTurning();
    }


    private void PerformMovement()
    {
        Vector3 newPosition = playerRigidbody.position + movement * maxSpeed * Time.deltaTime;
        if (Physics.CheckSphere(newPosition + new Vector3(0f, 2.0f, 0f), 0.01f, collisionMask) == false)   //Checks if the desired move position lies within a collider or not
        {
            playerRigidbody.MovePosition(newPosition);
        }
    }

    private void PerformTurning()
    {
        if (movement != Vector3.zero)
        {
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * turnSpeed);
        }
    }


    private void LateUpdate()
    {
        if (dead)
        {
            Vector3 revivePos = ramecanMixer.RootBoneTr.position;
            playerRigidbody.position = revivePos;
        }
    }



    //private void PerformMovement()
    //{
    //    Vector3 newPosition = ragdollRigidbody.position + movement * maxSpeed * Time.deltaTime;
    //    Vector3 groundCorrectedPosition = new Vector3(newPosition.x, GetGroundTargetHeight(), newPosition.z);

    //    if (Physics.CheckSphere(groundCorrectedPosition, 0.01f, groundMask) == false)   //Checks if the desired move position lies within a collider or not
    //    {
    //        ragdollRigidbody.MovePosition(groundCorrectedPosition);

    //        animator.SetFloat("Velocity X", movement.x);    //Set animation properties
    //        animator.SetFloat("Velocity Z", movement.z);
    //    }
    //    else
    //    {
    //        //Stops the walking animation when walking into walls.
    //        // OBS: This feature is optional!
    //        //animator.SetFloat("Velocity X", 0.0f);
    //        //animator.SetFloat("Velocity Z", 0.0f);
    //    }
    //}

    //private void PerformRotation()
    //{
    //    float xRot = movement.z * 8.0f;
    //    float yRot = movement.x * 70.0f;

    //    ragdollRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(xRot, yRot, 0), turnSpeed));
    //}

    //private float GetGroundTargetHeight()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(new Ray(ragdollHipsTransform.position, Vector3.down), out hit, fallHeight * 2, groundMask))
    //    {
    //        return hit.point.y + TARGET_DISTANCE_TO_GROUND;
    //    }

    //    return -fallHeight;
    //}

    //private bool IsGrounded()
    //{
    //    return Physics.Raycast(new Ray(ragdollHipsTransform.position, Vector3.down), 0.4f, groundMask);
    //}


    //private IEnumerator ToggleRagdollMode(float delayBefore = 0.0f, float delayAfter = 0.0f)
    //{
    //    canChangeMode = false;
    //    yield return new WaitForSeconds(delayBefore);

    //    if (ragdollMode && IsGrounded() == false)
    //    {
    //        yield return new WaitForSeconds(delayAfter);
    //        canChangeMode = true;
    //        yield break;
    //    }

    //    ragdollMode = !ragdollMode;
    //    ragdollRigidbody.isKinematic = !ragdollMode;
    //    animator.enabled = !ragdollMode;

    //    foreach (CopyJoint cj in copyJoints)
    //    {
    //        cj.ToggleJointMotion();
    //    }

    //    yield return new WaitForSeconds(delayAfter);
    //    canChangeMode = true;
    //}


    //private void RagdollLaunch()
    //{
    //    ragdollRigidbody.isKinematic = false;
    //    StartCoroutine(ToggleRagdollMode(0.0f, 2.0f));

    //    Vector3 launchDirection = (movement + Vector3.up * 2).normalized;
    //    Vector3 launchForce = ragdollLaunchMagnitude * launchDirection;

    //    ragdollRigidbody.AddForce(launchForce, ForceMode.VelocityChange);
    //}

}
