using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class d_InputController : MonoBehaviour
{
    Vector3 directionToMove = Vector3.zero;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(directionToMove * speed * Time.deltaTime);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputVector = value.ReadValue<Vector2>();
        directionToMove = new Vector3(inputVector.x, 0, inputVector.y);
        Debug.Log("Moving!");
    }

    public void OnThrow(InputAction.CallbackContext value)
    {
        Debug.Log("Thrown!");
    }
}
