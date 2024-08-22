using System.Collections;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public float collapseDelay = 1f; // Time in seconds before the platform collapses

    private bool isCollapsing = false;
    public bool Restart = false;
   
    [SerializeField] private Transform Checkpoint;
    // private Animator animator;

    [SerializeField] private CheckFalling CF;
    void Start()
    {
      //  animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollapsing) // Check if the player stepped on the platform
        {
            StartCoroutine(CollapsePlatform(collision));
            
        }
    }

    IEnumerator CollapsePlatform(Collision2D collision)
    {
        isCollapsing = true; // Prevent multiple triggers
        //animator.SetTrigger("Collapse"); // Trigger the collapse animation
        yield return new WaitForSeconds(collapseDelay);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.FallingPlatform, this.transform.position);
        gameObject.SetActive(false); // Disable the platform
        Restart = true;
        if(CF.Fallen == true)
        {
            Respawn(collision);
        }

    }
    /*void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Restart==true) // Check if the player has fallen off the platform
        {
            Debug.Log("restarting...");
            Respawn(collision);
        }
    }*/


    void Respawn(Collision2D collision)
    {
        if (Restart)
        {
            Debug.Log("collapse platform respawn");
            collision.transform.position = Checkpoint.position;
            this.gameObject.SetActive(true);
            Restart = false;
            isCollapsing = false; // Reset collapsing state
        }
    }


}

/*using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    private bool collidingWithPlayer = false;
    private float fallTimer;
    public float fallDelay; // How long before the platform falls?
    public float refreshDelay; // How long before the platform resets its decayed state?

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fallTimer = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            collidingWithPlayer = true;
        }
    }

    void Update()
    {
        if (collidingWithPlayer)
        {
            fallTimer += Time.deltaTime;
            if (fallTimer >= fallDelay)
            {
                rb2d.isKinematic = false;
                GetComponent<Collider2D>().isTrigger = true;
            }
        }
        else
        {
            // Reset the decayed state after a delay
            refreshTimer += Time.deltaTime;
            if (refreshTimer >= refreshDelay)
            {
                // Reset platform state here (e.g., disable decayed sprite)
            }
        }
    }
}
*/