using UnityEngine;
using static PlayerController;

public class CollisionDetection : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController _this = GetComponentInParent<PlayerController>();

        if (collision.gameObject.GetComponentInParent<PlayerController>())
        {
            PlayerController _other = collision.gameObject.GetComponentInParent<PlayerController>();

            if ((_other.Dead || _other.Reviving) && _this.RamecanMixer.RootBoneRb.velocity.magnitude > 0.5f)
            {
                _this.ToggleRagdollMode(RagdollMode.Ragdoll);
            }
        }
        else if (collision.transform.GetComponent<Rigidbody>())
        {
            Rigidbody _other = collision.transform.GetComponent<Rigidbody>();

            if (_other.velocity.magnitude >= 2.0f && !_this.Dead && !_this.Reviving)
            {
                _this.ToggleRagdollMode(RagdollMode.Ragdoll);
            }
        }
    }

}
