using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public static Vector3 lastCheckpointPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Update the last checkpoint position to this checkpoint's position
            lastCheckpointPos = transform.position;
            Debug.Log("Checkpoint reached at position: " + lastCheckpointPos);
        }
    }
}
