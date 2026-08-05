using UnityEngine;

public class DoorInteract : MonoBehaviour,IInteract
{
    [SerializeField] private DoorAnimationController doorAnimatorController;
    [SerializeField] private GemAnimationController  gemAnimatorController;

    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerInteraction playerInteraction;

    [SerializeField] private ItemData requiredKey;
    [SerializeField] public int requiredAmount;

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
        if (playerInventory.HasItem(requiredKey, requiredAmount))
        {
            doorAnimatorController.OpenDoor();
            gemAnimatorController.FadeGem();
            playerInventory.RemoveItem(requiredKey, requiredAmount);
            playerInteraction.ClearInteraction();
            interactCollider.enabled = false;
        }
        else
        {
            Debug.Log($"You need {requiredAmount} {requiredKey.ItemName}.");
        }
    }
}
