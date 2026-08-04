using System;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent (typeof(AnimatorController))]
public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void SetWalkingState(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }
}
