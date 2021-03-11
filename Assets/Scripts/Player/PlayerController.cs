using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;
    public static PlayerController Instance { get { return instance; } }


    [SerializeField] private float speed = 1.0f;

    //private ConfigurableJoint joint;
    private Rigidbody playerRigidbody;

    //private Transform ragdoll;
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
        ragdollRigidbody = transform.GetChild(0).GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            ToggleRagdollPhysics();

        if (ragdollEnabled == false)
        {
            Move();
            Rotate();
        }
    }


    private void ToggleRagdollPhysics()
    {
        ragdollEnabled = !ragdollEnabled;
        ragdollRigidbody.isKinematic = !ragdollEnabled;
        animator.enabled = !ragdollEnabled;
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
