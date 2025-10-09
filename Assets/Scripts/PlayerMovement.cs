using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Component References")]
    [SerializeField] Rigidbody2D playerRb;

    [Header("Player Setings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;

    private Vector2 startPosition;

    [Header("Dash Settings")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.4f;
    public float dashCooldown = 0.5f;

    private bool isDashing = false;
    private bool canDash = true;

    [SerializeField] private TrailRenderer dashTrail;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    private float horizontal;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
        startPosition = transform.position; 
    }

    void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(horizontal * moveSpeed, playerRb.linearVelocityY);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            Debug.Log("Jump");
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocityX, jumpHeight);  
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(context.performed && canDash && !isDashing)
        {
            Debug.Log("Dash");
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = playerRb.gravityScale;
        playerRb.gravityScale = 0;
        //TODO: FIX MOVEMENT
        playerRb.linearVelocity = new Vector2(transform.localScale.x * dashSpeed, 0f);
        dashTrail.emitting = true;
        yield return new WaitForSeconds(dashDuration);
        dashTrail.emitting = false;
        isDashing = false;
        playerRb.gravityScale = originalGravity;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.1f, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    public void OnSpike()
    {
        Debug.Log("Player hit spikes! Restarting level...");
        transform.position = startPosition; // Reset player position to origin
    }
}
