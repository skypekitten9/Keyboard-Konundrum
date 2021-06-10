using System.Collections;
using System.Collections.Generic;
using RagdollMecanimMixer;
using UnityEngine;

public class PlayerControllerDebug : MonoBehaviour
{
    private Rigidbody rb;
    private RamecanMixer ramecanMixer;
    [SerializeField] private LayerMask collisionMask;
    Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        ramecanMixer = GetComponent<RamecanMixer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = -Input.GetAxisRaw("Vertical");
        movement.z = Input.GetAxisRaw("Horizontal");
        movement.Normalize();

        
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = rb.position + movement * 5 * Time.deltaTime;

        if (Physics.CheckSphere(newPosition, 0.01f, collisionMask) == false)   //Checks if the desired move position lies within a collider or not
        {

            rb.MovePosition(newPosition);
        }
        
    }
}
