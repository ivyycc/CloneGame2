using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float openHeight = 3f; // How high the door should move when opening
    public float speed = 2f;      // Speed of the door movement

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    public LayerMask playerLayer; // Layer mask to check for players
    public float playerCheckRadius = 0.5f; // Radius for checking players underneath

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = new Vector3(transform.position.x, transform.position.y + openHeight, transform.position.z);
    }

    private void Update()
    {
        bool playerUnderneath = Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer);

        if (isOpen)
        {
            // Move the door to the open position
            transform.position = Vector3.Lerp(transform.position, openPosition, speed * Time.deltaTime);
        }
        else
        {
            if (playerUnderneath)
            {
                // Stop the door from closing completely if a player is underneath
                transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, closedPosition.y), transform.position.z);
            }
            else
            {
                // Move the door to the closed position
                transform.position = Vector3.Lerp(transform.position, closedPosition, speed * Time.deltaTime);
            }
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
