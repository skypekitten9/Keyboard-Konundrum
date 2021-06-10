using RagdollMecanimMixer;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 3.0f;                 //The max speed the player can move (units/second)
    [SerializeField] private float acceleration = 10.0f;            //Factor deciding how fast the player can accelerate. Greater value => reach max speed faster
    [SerializeField] private float turnSpeed = 5.0f;                //Factor deciding how fast the player can turn. Greater value => turn faster
    [SerializeField] private float launchMagnitude = 30.0f;         //The force exerted on the player when ragdoll-launching

    [SerializeField] private float minFallHeight = 0.5f;            //The minimum distance to the ground that the player can correct it's position to. Any greater distance causes a fall.

    [SerializeField] private float normalCorrectionFactor = 0.5f;   //How well alligned the player should be to the surface's normal.


    private Vector3 input = Vector3.zero;   //Movement input from gamepad/keyboard
    private Vector3 velocity = Vector3.zero;    //The actual player's velocity, after acceleration and maxSpeed clamp

    private float currentSpeedNormalized { get { return velocity.magnitude / maxSpeed; } } //Normalized player's speed, used in animations. [0, 1]

    private Transform playerTransform;
    private Rigidbody playerRigidbody;
    private RamecanMixer ramecanMixer;

    [SerializeField] private LayerMask excludeSelfMask;

    private bool dead { get { return playerRigidbody.isKinematic == true; } }
    private float deadTimer = 0f;
    private float deadDelay = 0.1f;

    private bool reviving = false;


    private enum RagdollMode { Animated, Ragdoll }

    private Animator animator;



    private void Awake()
    {
        playerTransform = transform.GetChild(0).transform;
        playerRigidbody = GetComponentInChildren<Rigidbody>();
        ramecanMixer = GetComponentInChildren<RamecanMixer>();

        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        velocity += input * acceleration * Time.deltaTime;
        if (velocity.magnitude > (input * maxSpeed).magnitude)
            velocity = input * maxSpeed;

        animator.SetFloat("MoveSpeed", currentSpeedNormalized);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    RagdollLaunch();
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (dead)
        //        ToggleRagdollMode(RagdollMode.Animated);
        //    else
        //        ToggleRagdollMode(RagdollMode.Ragdoll);
        //}
    }


    private void FixedUpdate()
    {
        PerformMovement();
        PerformTurning();

        GroundCorrection();
    }


    public void OnSetMovement(InputAction.CallbackContext value)
    {
        Vector2 inputVector = value.ReadValue<Vector2>();
        input = new Vector3(-inputVector.y, 0, inputVector.x);
    }

    /// <summary>
    /// Move the player according to the calculated velocity
    /// </summary>
    private void PerformMovement()
    {
        if (!dead && !reviving && velocity.magnitude > 0.1f)
        {
            playerRigidbody.velocity = velocity;
            //Debug.Log("velocity: " + velocity.magnitude);
        }
    }

    /// <summary>
    /// Turn the player based on the input movement direction
    /// </summary>
    private void PerformTurning()
    {
        if (!dead && !reviving && input != Vector3.zero)
        {
            float xRot = 0f;

            RaycastHit hit;
            if (Physics.Raycast(playerTransform.position, Vector3.down, out hit, minFallHeight, excludeSelfMask))
            {
                xRot = Vector3.Angle(Vector3.up, hit.normal) * Vector3.Dot(Vector3.forward, playerTransform.forward) * normalCorrectionFactor;
            }

            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.LookRotation(input) * Quaternion.Euler(xRot, 0, 0), Time.deltaTime * turnSpeed);
        }
    }


    private void LateUpdate()
    {
        if (dead)
        {
            deadTimer += Time.deltaTime;
            if (ramecanMixer.RootBoneRb.velocity.magnitude > 0.4f || ramecanMixer.RootBoneRb.angularVelocity.magnitude > 2.0f)
                deadTimer = 0;

            Vector3 revivePos = ramecanMixer.RootBoneTr.position;
            playerRigidbody.position = revivePos;    //Sets the position to revive to, to the ragdoll's position.

            Vector3 reviveDir = ramecanMixer.RootBoneTr.forward;
            playerRigidbody.rotation = Quaternion.Euler(0, Quaternion.LookRotation(-reviveDir, Vector3.up).y, 0);

            if (deadTimer >= deadDelay)
                StartCoroutine(Revive());
        }

        Debug.Log("up: " + ramecanMixer.RootBoneTr.up);
    }


    private IEnumerator Revive()
    {
        if (reviving)
            yield break;
        reviving = true;

        GroundCorrection();

        if (Vector3.Dot(ramecanMixer.RootBoneTr.forward, Vector3.up) > 0f)
            animator.SetTrigger("Revive_Up");
        else
            animator.SetTrigger("Revive_Down");

        yield return new WaitForSeconds(1.0f);
        ToggleRagdollMode(RagdollMode.Animated);

        yield return new WaitForSeconds(2.0f);
        reviving = false;
    }


    /// <summary>
    /// Moves the player to the ground OR triggers a ragdoll-fall
    /// </summary>
    private void GroundCorrection()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, Vector3.down, out hit, minFallHeight, excludeSelfMask))
        {
            if (hit.distance > 0.15f)
            {
                playerTransform.position = new Vector3(playerTransform.position.x, hit.point.y, playerTransform.position.z);
            }
        }
        else
        {
            ToggleRagdollMode(RagdollMode.Ragdoll);
        }
    }

    /// <summary>
    /// Function for switching between ragdoll-modes
    /// </summary>
    private void ToggleRagdollMode(RagdollMode mode)
    {
        switch (mode)
        {
            case RagdollMode.Animated:
                {
                    if (playerRigidbody.isKinematic == true)
                    {
                        ramecanMixer.BeginStateTransition("default");
                        playerRigidbody.isKinematic = false;
                    }
                }
                break;

            case RagdollMode.Ragdoll:
                {
                    if (!dead)
                    {
                        ramecanMixer.BeginStateTransition("dead");
                        playerRigidbody.isKinematic = true;
                        animator.SetTrigger("Die");
                    }
                }
                break;
        }
    }

    /// <summary>
    /// Trigger ragdoll mode and launch the ragdoll in the movement direction
    /// </summary>
    public void OnRagdollLaunch()
    {
        if (!dead)
        {
            ToggleRagdollMode(RagdollMode.Ragdoll);

            Vector3 launchDirection = (velocity + Vector3.up * 2).normalized;
            Vector3 launchForce = launchMagnitude * launchDirection;

            ramecanMixer.RootBoneRb.AddForce(launchForce, ForceMode.VelocityChange);
        }
    }


    private void OnDrawGizmos()
    {
        try
        {

        }
        catch (System.Exception) { }
    }

}
