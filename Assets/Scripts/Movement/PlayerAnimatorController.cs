
using UnityEngine;

[RequireComponent(typeof(Animator))]
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
