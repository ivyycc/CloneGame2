using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallArea : MonoBehaviour
{
    public CollapsingPlatform platform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player fell! Respawning at last checkpoint.");

            // Move the player to the last checkpoint position
            collision.transform.position = Checkpoint.lastCheckpointPos;

            // Find all collapsing platforms in the scene and reset them
            platform.ResetPlatform();
        }
    }
}
