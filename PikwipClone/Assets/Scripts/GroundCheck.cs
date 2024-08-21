using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // LayerMask to specify what layers count as ground
    public bool isGrounded; // Flag to track if the player is grounded

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we collided with is on the ground layer
        if (IsGroundedLayer(collision.gameObject.layer))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the object we exited is on the ground layer
        if (IsGroundedLayer(collision.gameObject.layer))
        {
            isGrounded = false;
        }
    }

    private bool IsGroundedLayer(int layer)
    {
        // Check if the layer of the collided object is in the groundLayer LayerMask
        return (groundLayer & (1 << layer)) != 0;
    }

    public bool IsGrounded()
    {
        // Public method to get the current grounded state
        return isGrounded;
    }
}
