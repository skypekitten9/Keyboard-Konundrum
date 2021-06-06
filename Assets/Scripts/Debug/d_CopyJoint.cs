using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_CopyJoint : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;
    private ConfigurableJoint configJoint;
    private bool active = false;
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

    public void ToggleJointMotion()
    {
        active = !active;
        if (active)
        {
            jointDriveX.positionSpring = initialPositionSpringX;
            jointDriveYZ.positionSpring = initialPositionSpringYZ;
            configJoint.angularXMotion = ConfigurableJointMotion.Free;
            configJoint.angularYMotion = ConfigurableJointMotion.Free;
            configJoint.angularZMotion = ConfigurableJointMotion.Free;
        }
        else
        {
            jointDriveX.positionSpring = 0;
            jointDriveYZ.positionSpring = 0;
            configJoint.angularXMotion = ConfigurableJointMotion.Limited;
            configJoint.angularYMotion = ConfigurableJointMotion.Limited;
            configJoint.angularZMotion = ConfigurableJointMotion.Limited;
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
