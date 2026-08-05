using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pauseScreenContainer;

    [Header("Input")]
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerCameraController playerCameraController;
    [SerializeField] private PlayerInteraction playerInteraction;

    private bool isOpen;

    private void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += TogglePause;
    }

    private void OnDisable()
    {
        pauseAction.action.performed -= TogglePause;
        pauseAction.action.Disable();
    }

    private void Start()
    {
        pauseScreenContainer.SetActive(false);
        isOpen = false;
    }

    private void OpenPause()
    {
        playerMovementController.moveAction.action.Disable();
        playerCameraController.lookAction.action.Disable();
        playerInteraction.interactAction.action.Disable();

        isOpen = true;
        pauseScreenContainer.SetActive(true);
    }

    public void ClosePause()
    {
        playerMovementController.moveAction.action.Enable();
        playerCameraController.lookAction.action.Enable();
        playerInteraction.interactAction.action.Enable();

        isOpen = false;
        pauseScreenContainer.SetActive(false);
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        if (isOpen)
            ClosePause();
        else
            OpenPause();
    }
}