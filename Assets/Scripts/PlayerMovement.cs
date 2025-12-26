using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public int health = 100;
    public float speed = 4.0f;
    public int damage = 30;
    public float jumpForce = 7f;

    [Header("References")]
    public ZombieHealth zombieHealth;
    public Animator mAnimator;
    public AudioSource footSteps;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private Vector2 movement;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footSteps = GetComponent<AudioSource>();
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        HandleActions();
    }

    private void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        // Set the "Speed" float (use absolute value so -1 becomes 1)
        mAnimator.SetFloat("Speed", Mathf.Abs(movement.x));

        if (movement.x != 0)
        {
            if (movement.x > 0 && !facingRight) Flip();
            else if (movement.x < 0 && facingRight) Flip();

            // The script now uses the trigger from the local file
            mAnimator.SetTrigger("IsWalking");

            transform.Translate(new Vector2(movement.x * speed * Time.deltaTime, 0));
            if (!footSteps.isPlaying && isGrounded) footSteps.Play();
        }
        else
        {
            footSteps.Stop();
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            // Set the Bool "IsJumping" to true
            mAnimator.SetBool("IsJumping", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void HandleActions()
    {
        // Shooting (S key)
        if (Input.GetKeyDown(KeyCode.S))
        {
            mAnimator.SetTrigger("isShooting");
            if (zombieHealth != null) zombieHealth.ZombieDamage(damage);
        }

        // Picking (Down Arrow)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            mAnimator.SetTrigger("isPicking");
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    // Basic ground detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}