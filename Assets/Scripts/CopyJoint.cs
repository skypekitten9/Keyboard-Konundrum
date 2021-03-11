using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyJoint : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;
    private ConfigurableJoint characterJoint;
    public bool enabled;
    Quaternion targetInitialRotation;

    void Start()
    {
        if(enabled)
        {
            this.characterJoint = this.GetComponent<ConfigurableJoint>();
            this.targetInitialRotation = this.targetLimb.transform.localRotation;
        }
        
    }

    private void FixedUpdate()
    {
        if (enabled)
        {
            characterJoint.targetRotation = copyRotation();
        }
    }

    private Quaternion copyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
}
