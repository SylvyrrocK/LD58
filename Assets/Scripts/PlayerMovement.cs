using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Component References")]
    [SerializeField] Rigidbody2D playerRb;

    [Header("Player Setings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    private float horizontal;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(horizontal * moveSpeed, playerRb.linearVelocityY);
    }

    public void onMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
             playerRb.linearVelocity = new Vector2(playerRb.linearVelocityX, jumpHeight);  
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.9f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
