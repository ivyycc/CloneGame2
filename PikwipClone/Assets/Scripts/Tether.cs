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

    private void Start()
    {
        // Set up the LineRenderer component
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
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
            Vector2 force = forceDirection * tetherForce * (currentDistance - tetherDistance);
            player1.AddForce(force);
            player2.AddForce(-force);
        }

        // Update the LineRenderer positions
        lineRenderer.SetPosition(0, player1.position);
        lineRenderer.SetPosition(1, player2.position);
    }
}
