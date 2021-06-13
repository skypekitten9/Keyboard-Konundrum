using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_Dispenser : MonoBehaviour
{
    [SerializeField] private float dispenseRate = 0.5f;     //dispenses per second
    private float timeSinceLastDispense = 0f;

    [SerializeField] private float dispenseForce = 10.0f;



    private void FixedUpdate()
    {
        timeSinceLastDispense += Time.fixedDeltaTime;

        if (timeSinceLastDispense >= 1.0f / dispenseRate)
        {
            timeSinceLastDispense = 0f;
            StartCoroutine(DispenseCube());
        }
    }

    private IEnumerator DispenseCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = this.transform.position;
        cube.transform.localScale *= 0.25f;
        cube.name = "dispensed_cube";
        cube.GetComponent<MeshRenderer>().sharedMaterial = this.GetComponent<MeshRenderer>().sharedMaterial;
        Rigidbody cube_rb = cube.AddComponent<Rigidbody>();
        cube_rb.mass = 100.0f;
        cube_rb.AddForce(transform.up * dispenseForce,ForceMode.VelocityChange);

        yield return new WaitForSeconds(5.0f);

        Destroy(cube);
    }
}
