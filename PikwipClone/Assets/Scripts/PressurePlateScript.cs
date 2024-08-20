using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public DoorScript door; // Reference to the DoorScript

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is a player
        if (collision.CompareTag("Player"))
        {
            door.OpenDoor(); // Call the OpenDoor method in the DoorScript
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the colliding object is a player
        if (collision.CompareTag("Player"))
        {
            door.CloseDoor(); // Call the CloseDoor method in the DoorScript
        }
    }
}
