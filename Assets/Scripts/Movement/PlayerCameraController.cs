using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensivity;

    private Rigidbody playerRb;

    public InputActionReference lookAction;

    private float yaw;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 mouseDelta = lookAction.action.ReadValue<Vector2>();

        yaw += mouseDelta.x * mouseSensivity;
    }

    private void FixedUpdate()
    {
        playerRb.MoveRotation(Quaternion.Euler(0f, yaw, 0f));
    }
}
