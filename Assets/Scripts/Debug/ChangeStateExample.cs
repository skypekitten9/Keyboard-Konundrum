using System.Collections;
using System.Collections.Generic;
using RagdollMecanimMixer;
using UnityEngine;
public class ChangeStateExample : MonoBehaviour
{
    private RamecanMixer ramecanMixer;
    private Rigidbody rb;
    private bool dead;

    void Start()
    {
        ramecanMixer = GetComponent<RamecanMixer>();
        rb = GetComponent<Rigidbody>();
        dead = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ramecanMixer.BeginStateTransition("default");
            dead = false;
            rb.isKinematic = false;
        }
            
        if (Input.GetKeyDown(KeyCode.E))
        {
            ramecanMixer.BeginStateTransition("dead");
            dead = true;
            rb.isKinematic = true;
        }
    }

    private void LateUpdate()
    {
        if(dead)
        {
            Vector3 revivePos = ramecanMixer.RootBoneTr.position;
            rb.position = new Vector3(revivePos.x, rb.position.y, revivePos.z);
        }
    }
}
