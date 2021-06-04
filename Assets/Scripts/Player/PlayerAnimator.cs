using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;



    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        animator.SetFloat("MoveSpeed", playerController.MoveSpeed);
    }


}
