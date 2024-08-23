using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public Rigidbody2D player1;
    public Rigidbody2D player2;
    public float tetherDistance = 2f;
    public float tetherForce = 10f;

    private LineRenderer lineRenderer;
    public int sortingOrder = 11;

    public float smoothingFactor = 0.1f;
    private Vector2 player1Velocity;
    private Vector2 player2Velocity;
    public Material tetherMaterial; // Assign this in the inspector
    private void Start()
    {
        // Set up the LineRenderer component
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;

        if (tetherMaterial != null)
        {
            lineRenderer.material = tetherMaterial; // Assign the custom material
        }
        else
        {
            Debug.LogWarning("Tether material not assigned.");
            lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Fallback
        }
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
         lineRenderer.sortingOrder = sortingOrder;
    }

    private void FixedUpdate()
    {
        Vector2 tetherVector = player2.position - player1.position;
        float currentDistance = tetherVector.magnitude;

        if (currentDistance > tetherDistance)
        {
            Vector2 forceDirection = tetherVector.normalized;
            Vector2 targetForce = forceDirection * tetherForce * (currentDistance - tetherDistance);

            // Gradually apply the forces using Mathf.Lerp for smoothness
            player1Velocity = Vector2.Lerp(player1Velocity, targetForce, smoothingFactor);
            player2Velocity = Vector2.Lerp(player2Velocity, -targetForce, smoothingFactor);

            player1.AddForce(player1Velocity);
            player2.AddForce(player2Velocity);
        }

        // Update the LineRenderer positions
        lineRenderer.SetPosition(0, player1.position);
        lineRenderer.SetPosition(1, player2.position);
    }
}
