using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public int health = 100;
    public float speed = 4.0f;
    public int damage = 30;
    public float jumpForce = 5f;

    [Header("References")]
    public ZombieHealth zombieHealth;
    public Animator mAnimator;
    public AudioSource footSteps;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector2 movement;

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
        HandleIdleState();
    }

    // .
    private void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (movement.x != 0)
        {
            mAnimator.SetTrigger("isWalking");
            transform.Translate(new Vector2(movement.x * speed * Time.deltaTime, 0));

            if (!footSteps.isPlaying)
                footSteps.Play();
        }
    }

    // .
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            mAnimator.SetTrigger("isJumping");
            footSteps.Stop();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // .
    private void HandleActions()
    {
        // Shooting
        if (Input.GetKeyDown(KeyCode.S))
        {
            mAnimator.SetTrigger("isShooting");
            if (zombieHealth != null)
                zombieHealth.ZombieDamage(damage);
        }

        // Picking
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            mAnimator.SetTrigger("isPicking");
            footSteps.Stop();
        }
    }

    // .
    private void HandleIdleState()
    {
        if (movement.x == 0 && !Input.anyKey)
        {
            mAnimator.SetTrigger("isIdle");
            footSteps.Stop();
        }
    }

}