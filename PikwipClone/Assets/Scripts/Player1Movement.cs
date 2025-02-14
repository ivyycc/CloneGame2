using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    [SerializeField] private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
   // public Transform groundCheck;
    public LayerMask groundLayer;
    private Animator animator;
    [SerializeField] ParticleSystem snow;

    [Header("Controls")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

   // public bool isGrounded;
    public Rigidbody2D tetheredPlayer;
    public float tetherDistance;

    public GroundCheck GroundCheck; // Change the type to GroundCheck
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        horizontal = 0f;

        if (Input.GetKey(leftKey))
        {
            horizontal = -1f;
            animator.SetBool("isRunning", true);
            snow.Play();
        }
        else if (Input.GetKey(rightKey))
        {
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

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || IsGroundedLayer(collision.gameObject.layer))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || IsGroundedLayer(collision.gameObject.layer))
        {
            isGrounded = false;
        }
    }

    private bool IsGroundedLayer(int layer)
    {
        return (groundLayer & (1 << layer)) != 0;
    }*/
}
