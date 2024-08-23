using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // LayerMask to specify what layers count as ground
    public Transform[] groundCheckPoints; // Array of points to check for ground
    public float checkRadius = 0.2f; // Radius for ground check
    public float groundCheckDelay = 0.1f; // Delay between ground checks to smooth transitions

    public bool isGrounded; // Flag to track if the player is grounded
    private bool lastGroundedState;

    private void Start()
    {
        StartCoroutine(GroundCheckRoutine());
    }

    private IEnumerator GroundCheckRoutine()
    {
        while (true)
        {
            CheckGroundedStatus();
            yield return new WaitForSeconds(groundCheckDelay);
        }
    }

    private void CheckGroundedStatus()
    {
        //lastGroundedState = isGrounded;

        foreach (Transform point in groundCheckPoints)
        {
            // Check if any of the ground check points are touching the ground layer
            if (Physics2D.OverlapCircle(point.position, checkRadius, groundLayer))
            {
                isGrounded = true;
                return;
            }
        }

        isGrounded = false;

        // Optional smoothing: If the player was just grounded, keep them grounded for a brief moment
        if (lastGroundedState && !isGrounded)
        {
            StartCoroutine(TemporaryGrounding());
        }
    }

    private IEnumerator TemporaryGrounding()
    {
        isGrounded = true;
        yield return new WaitForSeconds(groundCheckDelay);
        isGrounded = false;
    }

    public bool IsGrounded()
    {
        // Public method to get the current grounded state
        return isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw ground check gizmos for debugging
        Gizmos.color = Color.red;
        foreach (Transform point in groundCheckPoints)
        {
            Gizmos.DrawWireSphere(point.position, checkRadius);
        }
    }
}
