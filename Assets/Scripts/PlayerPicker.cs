using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    public void PickRagdollPlayers(int i)
    {
        PlayerManager.Instance.InstantiatePlayers(i);
        Destroy(gameObject);
    }
}
