using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    [SerializeField] Transform playerTransform;
    public float chaseDistance = 20f;
    public float attackDistance = 2f;

    [Header("References")]
    public Animator mAnimator;
    public AudioSource walking;

    private void Start()
    {
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
                Debug.LogError("Player not found!", this);
                enabled = false;
            }
        }

        // Initialize animator if not assigned
        if (mAnimator == null)
            mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Idle by default
        bool shouldChase = distanceToPlayer < chaseDistance && distanceToPlayer > attackDistance;
        bool shouldAttack = distanceToPlayer <= attackDistance;

        // Update animator states
        mAnimator.SetBool("isWalking", shouldChase);
        mAnimator.SetBool("isAttacking", shouldAttack);

        // Handle movement and audio
        if (shouldChase)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (!walking.isPlaying)
                walking.Play();
        }
        else
        {
            if (walking.isPlaying)
                walking.Stop();
        }
    }
}