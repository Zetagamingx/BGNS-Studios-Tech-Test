using TMPro;
using UnityEngine;

public class TombInteract : MonoBehaviour, IInteract
{
    [SerializeField] GameObject itemDialogueContainer;
    [SerializeField] TextMeshProUGUI dialogueBoxText;
    [SerializeField] PlayerInteraction playerInteraction;
    [SerializeField] PlayerMovementController playerMovementController;
    [SerializeField] PlayerCameraController playerCameraController;
    public string InteractionPrompt => "mmm... feels like I am missing something, oh well, guess I will sleep here tonight";

    public void Interact()
    {
        playerInteraction.interactAction.action.Disable();
        playerMovementController.moveAction.action.Disable();
        playerCameraController.lookAction.action.Disable();

        itemDialogueContainer.SetActive(true);
        dialogueBoxText.SetText(InteractionPrompt);
    }
}
