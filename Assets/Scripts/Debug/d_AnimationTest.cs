using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_AnimationTest : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0f;
    float velocityX = 0f;
    bool standing = false;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            velocityZ += Time.deltaTime * acceleration;
            if (velocityZ > 2) velocityZ = 2;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            velocityZ -= Time.deltaTime * acceleration;
            if (velocityZ < -2) velocityZ = -2;
        }
        animator.SetFloat("Velocity Z", velocityZ);

        if(Input.GetKey(KeyCode.L))
        {
            velocityX += Time.deltaTime * acceleration;
            if (velocityX > 2) velocityX = 2;
        }
        else if(Input.GetKey(KeyCode.J))
        {
            velocityX -= Time.deltaTime * acceleration;
            if (velocityX < -2) velocityX = -2;
        }
        animator.SetFloat("Velocity X", velocityX);

        if (Input.GetKeyDown(KeyCode.P))
        {
            standing = !standing;
            animator.SetBool("Standing", standing);
        }
    }
}
