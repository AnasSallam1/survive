using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public float speed = 3.5f;
    public int patrolDestination;
    public Transform playerTranform;
    public float playerPosition;
    public float zombiePosition;
    public GameObject player;
    public Animator mAnimator;
    public Vector2 movement = new Vector2();
    public AudioSource footSteps;
    public bool isAttacking;

    //.
    private void Start()
    {
        playerPosition = player.GetComponent<Player>().playerPosition;
        footSteps = GetComponent<AudioSource>();
    }

    void Update()
    {
        mAnimator = GetComponent<Animator>();
        isAttacking = false;

        // Zombie is walking.
        if ((zombiePosition - playerPosition) <= 26)
        {
            mAnimator.Play("Walk");
            footSteps.Play();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * speed * Time.deltaTime, 0);
            transform.Translate(-newPosition);
            zombiePosition = -newPosition.x;
        }

        // .
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mAnimator.Play("Jump");
            footSteps.Stop();
            movement.y = Input.GetAxisRaw("Vertical");
            Vector2 newPosition = new Vector2(0, movement.y * 5 * Time.deltaTime);
            transform.Translate(newPosition);
        }

        // Zombie is attacking the player.
        if ((zombiePosition - playerPosition) <= 2)
        {
            zombieAttack();
        }

        // Player is punching the zombie.
        if (Input.GetKey(KeyCode.D))
        {
            zombieHit();
        }

        // Zombie is dead.
        if (health <= 0)
        {
            mAnimator.Play("Dead-1");
        }
    }

    // .
    public void zombieAttack()
    {
        isAttacking = true;
        mAnimator.Play("Attack");
        player.GetComponent<Player>().playerHit();
    }

    // .
    public void zombieHit()
    {
        mAnimator.Play("Hit");
        health -= 10;
    }

}
