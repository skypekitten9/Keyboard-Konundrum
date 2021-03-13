using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    Animator animator;
    float velocity = 0f;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            velocity += Time.deltaTime * acceleration;
            if (velocity > 1) velocity = 1;
        }
        else
        {
            velocity -= Time.deltaTime * acceleration;
            if (velocity < 0) velocity = 0;
        }
        animator.SetFloat("Velocity", velocity);
    }
}
