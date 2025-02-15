using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] Transform playerTransform; // Assign via Inspector or auto-detect
    public bool isChasing;
    public bool isAttacking;
    public float chaseDistance = 20f; // Initialize here
    public float attackDistance = 2f;

    public Animator mAnimator;
    public AudioSource walking;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();

        // Auto-detect player if not assigned
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            else
            {
                Debug.LogError("Player not found! Assign a player or tag your player GameObject with 'Player'.", this);
                enabled = false; // Disable script
            }
        }
    }

    void Update()
    {
        if (playerTransform == null) return; // Guard clause

        // Zombie chase logic
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < chaseDistance && distanceToPlayer > attackDistance)
        {
            isChasing = true;
            isAttacking = false;

            mAnimator.SetTrigger("isWalking");
            if (!walking.isPlaying) walking.Play();

            // Move towards player
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Flip sprite based on direction
            if (direction.x < 0)
                transform.localScale = new Vector3(-1, 1, 1); // Flip left
            else
                transform.localScale = new Vector3(1, 1, 1); // Flip right
        }
        else if (distanceToPlayer <= attackDistance)
        {
            isChasing = false;
            isAttacking = true;

            mAnimator.SetTrigger("isAttacking");
            walking.Stop();
        }
        else
        {
            isChasing = false;
            isAttacking = false;
            walking.Stop();
        }
    }
}