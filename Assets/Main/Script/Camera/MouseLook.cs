using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 200f;

    float xRotation = 0f;
    private Vector2 lookInput;

    private Quaternion initialCameraRotation;

    void Start()
    {
        // ƒJƒƒ‰‚Ì‰Šú‰ñ“]‚ğ•Û‘¶
        initialCameraRotation = transform.localRotation;
    }

    void Update()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // ‰Šú‰ñ“] + ƒ}ƒEƒX‰ñ“]
        transform.localRotation = initialCameraRotation * Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}