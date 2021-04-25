using System.Collections;
using System.Collections.Generic;
using RagdollMecanimMixer;
using UnityEngine;
public class ChangeStateExample : MonoBehaviour
{
    private RamecanMixer ramecanMixer;
    void Start()
    {
        ramecanMixer = GetComponent<RamecanMixer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ramecanMixer.BeginStateTransition("default");
        if (Input.GetKeyDown(KeyCode.DownArrow))
            ramecanMixer.BeginStateTransition("dead");
    }
}
