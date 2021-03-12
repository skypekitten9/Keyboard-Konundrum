using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;
    public static PlayerController Instance { get { return instance; } }


    private Vector3 movement = Vector3.zero;

    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 3.0f;


    private Rigidbody playerRigidbody;

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

        playerRigidbody = GetComponent<Rigidbody>();
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
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
            movement.Normalize();
        }
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
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


    private void PerformMovement()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement * moveSpeed * Time.deltaTime);
    }

    private void PerformRotation()
    {
        if (movement != Vector3.zero)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(movement), Time.deltaTime * rotationSpeed);
        }
    }

}
