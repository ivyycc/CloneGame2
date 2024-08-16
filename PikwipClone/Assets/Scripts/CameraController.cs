using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform player1; 
    public Transform player2; 
    public float smoothing = 0.125f; // Smoothing factor for the camera movement
    public Vector3 offset; // Offset between the player and camera
    public float minZoom = 5f; // Minimum  size for zooming
    public float maxZoom = 10f; // Maximum  size for zooming
    public float zoomSpeed = 1f; // Speed at which the camera zooms
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (player1 != null && player2 != null)
        {
            // midpoint between player1 and player2
            Vector3 midpoint = (player1.position + player2.position) / 2;

            // Add the offset to the midpoint
            Vector3 desiredPosition = midpoint + offset;

            // Smoothly transition to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing);
            transform.position = smoothedPosition;

            // Calculate the distance between the two players
            float distance = Vector3.Distance(player1.position, player2.position);

            // Adjust the camera's orthographic size based on the distance between the players
            float zoomFactor = Mathf.Lerp(maxZoom, minZoom, distance / (maxZoom - minZoom));
            cam.orthographicSize = Mathf.Clamp(zoomFactor, minZoom, maxZoom);

            // Handle manual zoom with the mouse scroll wheel
            float scrollData = Input.GetAxis("Mouse ScrollWheel");
            cam.orthographicSize -= scrollData * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
