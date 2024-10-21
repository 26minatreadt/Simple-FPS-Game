// Scripts/FPSCameraMovement.cs
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
    public float verticalRotationLimit = 80f; // Limit for vertical rotation

    private float xRotation = 0f; // Current vertical rotation
    private float yRotation = 0f; // Current horizontal rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalRotationLimit, verticalRotationLimit); // Clamp the vertical rotation

        // Rotate the camera horizontally
        yRotation += mouseX;

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
