using UnityEngine;

public class DoorInteract : MonoBehaviour,IInteract
{
    [SerializeField] private DoorAnimationController doorAnimatorController;
    [SerializeField] private GemAnimationController  gemAnimatorController;

    [SerializeField] private PlayerInventory playerInventory;

    [SerializeField] private ItemData requiredKey;

    private BoxCollider interactCollider;
    public string InteractionPrompt => throw new System.NotImplementedException();

    private void Awake()
    {
        interactCollider = GetComponent<BoxCollider>();
        if (playerInventory == null)
        {
            playerInventory = FindFirstObjectByType<PlayerInventory>();
        }
    }
    public void Interact()
    {
        if (playerInventory.HasItem(requiredKey))
        {
            doorAnimatorController.OpenDoor();
            gemAnimatorController.FadeGem();
            interactCollider.enabled = false;
        }
        else
        {
            Debug.Log("You need the key.");
        }
        
    }

    
}
