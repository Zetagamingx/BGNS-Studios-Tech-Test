using UnityEngine;

public class DoorInteract : MonoBehaviour,IInteract
{
    [SerializeField] private DoorAnimationController doorAnimatorController;
    [SerializeField] private GemAnimationController  gemAnimatorController;

    private BoxCollider interactCollider;
    public string InteractionPrompt => throw new System.NotImplementedException();

    private void Awake()
    {
        interactCollider = GetComponent<BoxCollider>();
    }
    public void Interact()
    {
        doorAnimatorController.OpenDoor();
        gemAnimatorController.FadeGem();
        interactCollider.enabled = false;
    }

    
}
