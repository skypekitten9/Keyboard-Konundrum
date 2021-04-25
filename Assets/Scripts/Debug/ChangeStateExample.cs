using System.Collections;
using System.Collections.Generic;
using RagdollMecanimMixer;
using UnityEngine;
public class ChangeStateExample : MonoBehaviour
{
    private RamecanMixer ramecanMixer;
    private Rigidbody rb;
    void Start()
    {
        ramecanMixer = GetComponent<RamecanMixer>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 revivePos = ramecanMixer.RootBoneTr.position;
            rb.position = new Vector3(revivePos.x, rb.position.y, revivePos.z);
            ramecanMixer.BeginStateTransition("default");
        }
            
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ramecanMixer.BeginStateTransition("dead");
        }

      
    }
}
