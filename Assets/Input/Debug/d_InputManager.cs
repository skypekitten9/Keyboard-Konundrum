using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_InputManager : MonoBehaviour
{
    public GameObject playerToInstansiate;
    List<d_InputController> playerList;

    // Start is called before the first frame update
    void Start()
    {
        playerList = new List<d_InputController>();
        Vector3 spawnPos = Vector3.zero;
        for (int i = 0; i < 3; i++)
        {
            GameObject spawnedPlayer = Instantiate(playerToInstansiate, spawnPos, Quaternion.identity) as GameObject;
            spawnPos.x = spawnPos.x + 1;
            playerList.Add(spawnedPlayer.GetComponent<d_InputController>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
