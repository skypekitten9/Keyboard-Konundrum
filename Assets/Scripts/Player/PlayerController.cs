using RagdollMecanimMixer;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 3.0f;
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float turnSpeed = 5.0f;
    [SerializeField] private float launchMagnitude = 30.0f;

    [SerializeField] private float minFallHeight = 0.5f;

    [SerializeField] private float normalCorrectionFactor = 0.5f;


    private Vector3 input = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    public float currentSpeedNormalized { get { return velocity.magnitude / maxSpeed; } } //[0, 1]

    private Transform playerTransform;
    private Rigidbody playerRigidbody;
    private RamecanMixer ramecanMixer;

    [SerializeField] private LayerMask excludeSelfMask;


    private enum RagdollMode { Animated, Ragdoll }



    private void Awake()
    {
        playerTransform = transform.GetChild(0).transform;
        playerRigidbody = GetComponentInChildren<Rigidbody>();
        ramecanMixer = GetComponentInChildren<RamecanMixer>();
    }


    private void Update()
    {
        input.x = -Input.GetAxisRaw("Vertical");
        input.z = Input.GetAxisRaw("Horizontal");
        if (input.magnitude > 1.0f)
            input.Normalize();

        velocity += input * acceleration * Time.deltaTime;
        if (velocity.magnitude > (input * maxSpeed).magnitude)
            velocity = input * maxSpeed;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            RagdollLaunch();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleRagdollMode(RagdollMode.Animated);
        }
    }


    private void FixedUpdate()
    {
        PerformMovement();
        PerformTurning();

        GroundCorrection();
    }


    private void PerformMovement()
    {
        if (playerRigidbody.isKinematic == false && velocity.magnitude > 0.1f)
        {
            playerRigidbody.velocity = velocity;
            //Debug.Log("velocity: " + velocity.magnitude);
        }
    }

    private void PerformTurning()
    {
        if (input != Vector3.zero && playerRigidbody.isKinematic == false)
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
        if (playerRigidbody.isKinematic == true)
        {
            Vector3 revivePos = ramecanMixer.RootBoneTr.position;
            playerRigidbody.position = revivePos;
        }
    }


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
                    if (playerRigidbody.isKinematic == false)
                    {
                        ramecanMixer.BeginStateTransition("dead");
                        playerRigidbody.isKinematic = true;
                    }
                }
                break;
        }
    }


    private void RagdollLaunch()
    {
        if (playerRigidbody.isKinematic == false)
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
            //Gizmos.color = IsGrounded() ? Color.green : Color.red;
            //Gizmos.DrawWireSphere(playerTransform.position, 1.0f);
        }
        catch (System.Exception) { }
    }

}
