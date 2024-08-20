using System.Collections;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public float collapseDelay = 2f; // Time in seconds before the platform collapses

    private bool isCollapsing = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollapsing) // Check if the player stepped on the platform
        {
            StartCoroutine(CollapsePlatform());
        }
    }

    IEnumerator CollapsePlatform()
    {
        isCollapsing = true; // Prevent multiple triggers
        yield return new WaitForSeconds(collapseDelay);
        gameObject.SetActive(false); // Disable the platform
    }
}
