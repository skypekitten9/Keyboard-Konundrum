using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyJoint : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;
    private ConfigurableJoint configJoint;
    private bool active;
    private float initialPositionSpringX;
    private float initialPositionSpringYZ;

    private JointDrive jointDriveX;
    private JointDrive jointDriveYZ;
    Quaternion targetInitialRotation;

    void Start()
    {
        this.configJoint = this.GetComponent<ConfigurableJoint>();
        active = true;
        initialPositionSpringX = configJoint.angularXDrive.positionSpring;
        initialPositionSpringYZ = configJoint.angularYZDrive.positionSpring;

        this.jointDriveX = configJoint.angularXDrive;
        this.jointDriveYZ = configJoint.angularYZDrive;
        this.targetInitialRotation = this.targetLimb.transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            active = !active;
            if (active)
            {
                jointDriveX.positionSpring = initialPositionSpringX;
                jointDriveYZ.positionSpring = initialPositionSpringYZ;
            }
            else
            {
                jointDriveX.positionSpring = 0;
                jointDriveYZ.positionSpring = 0;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (active)
        {
            configJoint.targetRotation = copyRotation();
        }
        configJoint.angularXDrive = jointDriveX;
        configJoint.angularYZDrive = jointDriveYZ;
    }

    private Quaternion copyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
}
