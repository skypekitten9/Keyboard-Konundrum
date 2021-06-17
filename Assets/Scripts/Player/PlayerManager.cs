using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{

    //Player
    public GameObject playerToInstansiate;
    List<d_InputController> playerList;

    private void Start()
    {
        InstantiatePlayers();   
    }

    private void InstantiatePlayers()
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
}
