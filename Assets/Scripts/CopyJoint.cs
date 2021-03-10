using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyJoint : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;
    private CharacterJoint characterJoint;
    Quaternion targetInitialRotation;

    //void Start()
    //{
    //    this.characterJoint = this.GetComponent<CharacterJoint>();
    //    this.targetInitialRotation = this.targetLimb.transform.localRotation;
    //}

    //private void FixedUpdate()
    //{
    //    characterJoint.targetRotation = copyRotation();
    //}

    //private Quaternion copyRotation()
    //{
    //    return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    //}
}
