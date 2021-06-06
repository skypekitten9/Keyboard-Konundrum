using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDebugManager : MonoBehaviour
{
    public GameObject playerToInstansiate;
    List<InputDebugController> playerList;

    // Start is called before the first frame update
    void Start()
    {
        playerList = new List<InputDebugController>();
        Vector3 spawnPos = Vector3.zero;
        for (int i = 0; i < 3; i++)
        {
            GameObject spawnedPlayer = Instantiate(playerToInstansiate, spawnPos, Quaternion.identity) as GameObject;
            spawnPos.x = spawnPos.x + 1;
            playerList.Add(spawnedPlayer.GetComponent<InputDebugController>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
