using UnityEngine;

public class InputManagerController : MonoBehaviour
{
    public static InputManagerController Instance { get; private set; }

    public InputSystem_Actions InputActions { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InputActions = new InputSystem_Actions();
        InputActions.Player.Enable();
    }

    public void EnablePlayer()
    {
        InputActions.Player.Enable();
    }

    public void DisablePlayer()
    {
        InputActions.Player.Disable();
    }

    public void EnableUI()
    {
        InputActions.UI.Enable();
    }

    public void DisableUI()
    {
        InputActions.UI.Disable();
    }

    public void EnterDialogue()
    {
        DisablePlayer();
        EnableUI();
    }

    public void ExitDialogue()
    {
        DisableUI();
        EnablePlayer();
    }

    private void OnDestroy()
    {
        InputActions.Dispose();
    }
}