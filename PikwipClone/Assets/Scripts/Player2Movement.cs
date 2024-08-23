using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    [SerializeField] private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    public LayerMask groundLayer;
    private Animator animator;
    [SerializeField] ParticleSystem snow;

    [Header("Controls")]
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode jumpKey = KeyCode.UpArrow;

    //public bool isGrounded;

    public Rigidbody2D tetheredPlayer;
    public float tetherDistance;

    public GroundCheck GroundCheck; // Change the type to GroundCheck
    [SerializeField] private GameManager GM;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        horizontal = 0f;

        if (Input.GetKey(leftKey))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.playerWalk, this.transform.position);
            horizontal = -1f;
            animator.SetBool("isRunning", true);
            snow.Play();
        }
        else if (Input.GetKey(rightKey))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.playerWalk, this.transform.position);
            horizontal = 1f;
            animator.SetBool("isRunning", true);
            snow.Play();
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Allow jumping only if grounded
        if (Input.GetKeyDown(jumpKey) && GroundCheck.IsGrounded())
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.playerJump, this.transform.position);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyUp(jumpKey) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {

        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //float currentDistance = Vector2.Distance(rb.position, tetheredPlayer.position);

        //    //Modified ground check logic considering tether distance
        //if (IsGrounded() && currentDistance <= tetherDistance)
        //{
        //    isGrounded = true;
        //}
        //else if (currentDistance > tetherDistance)
        //{
        //    isGrounded = IsGrounded();
        //}
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            GM.QuitGame();
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player") || IsGroundedLayer(collision.gameObject.layer))
    //    {
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player") || IsGroundedLayer(collision.gameObject.layer))
    //    {
    //        isGrounded = false;
    //    }
    //}

    //public bool IsGroundedLayer(int layer)
    //{
    //    return (groundLayer & (1 << layer)) != 0;
    //}

    //private bool IsGrounded()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    //}
}