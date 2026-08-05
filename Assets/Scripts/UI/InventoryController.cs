using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject inventoryPanel;

    [Header("Input")]
    [SerializeField] private InputActionReference inventoryAction;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerCameraController playerCameraController;
    [SerializeField] private PlayerInteraction playerInteraction;

    private bool isOpen;

    private void OnEnable()
    {
        inventoryAction.action.Enable();
        inventoryAction.action.performed += ToggleInventory;
    }

    private void OnDisable()
    {
        inventoryAction.action.performed -= ToggleInventory;
        inventoryAction.action.Disable();
    }

    private void Start()
    {
        inventoryPanel.SetActive(false);
        isOpen = false;
    }

    private void OpenInventory()
    {
        playerMovementController.moveAction.action.Disable();
        playerCameraController.lookAction.action.Disable();
        playerInteraction.interactAction.action.Disable();

        isOpen = true;
        inventoryPanel.SetActive(true);
    }

    private void CloseInventory()
    {
        playerMovementController.moveAction.action.Enable();
        playerCameraController.lookAction.action.Enable();
        playerInteraction.interactAction.action.Enable();

        isOpen = false;
        inventoryPanel.SetActive(false);
    }

    private void ToggleInventory(InputAction.CallbackContext context)
    {
        if (isOpen)
            CloseInventory();
        else
            OpenInventory();
    }
}