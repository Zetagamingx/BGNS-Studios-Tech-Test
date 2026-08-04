using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{
    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");        
    }
}
