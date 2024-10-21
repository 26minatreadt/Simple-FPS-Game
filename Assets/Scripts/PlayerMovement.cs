// Scripts/playermovement.cs
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Normal movement speed
    public float jumpHeight = 1.5f; // Height of the jump
    public float gravity = -9.81f; // Gravity value

    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 velocity; // Current velocity of the player
    private bool isGrounded; // Check if the player is on the ground

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component
        isGrounded = controller.isGrounded; // Check if the player is grounded
    }

    void Update()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Reset vertical velocity when grounded
        }

        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        Vector3 move = transform.right * horizontal + transform.forward * vertical; // Calculate movement direction
        controller.Move(move * moveSpeed * Time.deltaTime); // Move the player

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime; // Apply gravity to the vertical velocity
        controller.Move(velocity * Time.deltaTime); // Move the player based on velocity
    }
}
