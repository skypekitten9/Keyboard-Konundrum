using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    private ConfigurableJoint cj;
    private Transform ragdoll;
    private Rigidbody rb;


    private void Awake()
    {
        cj = transform.GetComponentInChildren<ConfigurableJoint>();
        ragdoll = transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Move();
        Rotate();
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

        rb.AddForce(moveVector.normalized * Time.deltaTime * speed, ForceMode.VelocityChange);
    }

    private void Rotate()
    {

    }

}
