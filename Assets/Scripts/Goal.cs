using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool gameOver = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" && !gameOver)
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
            gameOver = true;
            GameManager.Instance.Win(WinType.Player);
        }
    }
}
