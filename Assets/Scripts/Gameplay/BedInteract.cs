using TMPro;
using UnityEngine;

public class BedInteract : MonoBehaviour, IInteract
{
    [SerializeField] GameObject itemDialogueContainer;
    [SerializeField] TextMeshProUGUI dialogueBoxText;
    [SerializeField] PlayerInteraction playerInteraction;
    [SerializeField] PlayerMovementController playerMovementController;
    [SerializeField] PlayerCameraController playerCameraController;
    public string InteractionPrompt => "well, well, well, thats what I am talking about! Time to Zzzz";

    public void Interact()
    {
        playerInteraction.interactAction.action.Disable();
        playerMovementController.moveAction.action.Disable();
        playerCameraController.lookAction.action.Disable();

        itemDialogueContainer.SetActive(true);
        dialogueBoxText.SetText(InteractionPrompt);
    }
}
