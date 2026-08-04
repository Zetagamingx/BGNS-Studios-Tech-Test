using UnityEngine;

public class GemAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeGem()
    {
        animator.SetTrigger("FadeGem");
    }
}
