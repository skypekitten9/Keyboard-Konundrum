using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    private ConfigurableJoint cj;
    private Transform ragdoll;


    private void Awake()
    {
        cj = transform.GetComponentInChildren<ConfigurableJoint>();
        ragdoll = transform.GetChild(0);
    }


    private void Update()
    {
        Move();
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ragdoll.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ragdoll.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ragdoll.position += Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ragdoll.position += Vector3.back * speed;
        }
        if (Input.GetKey(KeyCode.K))
        {
            ragdoll.position += Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.L))
        {
            ragdoll.position += Vector3.down * speed;
        }
    }
}
