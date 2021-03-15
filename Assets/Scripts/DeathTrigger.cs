using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Win(WinType.Keyboard);
    }
}
