using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;
    public static PlayerController Instance { get { return instance; } }


    private const float standingHeight = 0.66f;

    [SerializeField] private float speed = 1.0f;

    //private ConfigurableJoint joint;
    private Rigidbody playerRigidbody;

    //private Transform ragdoll;
    private Transform ragdollTransform;
    private Transform ragdollhipsTransform;
    private Rigidbody ragdollRigidbody;
    private Animator animator;

    private bool ragdollEnabled = false;


    private void Awake()
    {
        if (Instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        //joint = transform.GetComponentInChildren<ConfigurableJoint>();
        playerRigidbody = GetComponent<Rigidbody>();

        //ragdoll = transform.GetChild(0);
        ragdollTransform = transform.GetChild(0).GetComponent<Transform>();
        ragdollhipsTransform = transform.GetChild(0).GetChild(2).GetComponent<Transform>();
        ragdollRigidbody = transform.GetChild(0).GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            StartCoroutine(ToggleRagdollPhysics());

        if (ragdollEnabled == false)
        {
            Move();
            Rotate();
        }
    }


    private IEnumerator ToggleRagdollPhysics()
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
    }

    private void Move()
    {
        Vector3 moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVector += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVector += Vector3.back;
        }
        if (Input.GetKey(KeyCode.K))
        {
            moveVector += Vector3.up;
        }
        if (Input.GetKey(KeyCode.L))
        {
            moveVector += Vector3.down;
        }

        playerRigidbody.AddForce(moveVector.normalized * Time.deltaTime * speed, ForceMode.VelocityChange);
    }

    private void Rotate()
    {

    }

}
