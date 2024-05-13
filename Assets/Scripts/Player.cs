using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public float speed = 4.0f;
    public float playerPosition;
    public GameObject zombie;
    public Animator mAnimator;
    public Vector2 movement = new Vector2();
    public AudioSource footSteps;
    bool isWalking;
    bool isJumping;

    //.
    private void Start()
    {
        footSteps = GetComponent<AudioSource>();
    }

    private void Update()
    {
        mAnimator = GetComponent<Animator>();
        isWalking = false;

        // Player is walking.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isWalking = true;
            mAnimator.Play("Walk");
            footSteps.Play();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * speed * Time.deltaTime, 0);
            transform.Translate(newPosition);
            Console.WriteLine("Player Position X : " + newPosition.x);
            playerPosition = newPosition.x;

        }

        // Player is jumping.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mAnimator.Play("Jump");
            footSteps.Stop();
            movement.y = Input.GetAxisRaw("Vertical");
            Vector2 newPosition = new Vector2(0, movement.y * 5 * Time.deltaTime);
            transform.Translate(newPosition);
        }

        // Player is punching.
        if (Input.GetKey(KeyCode.D))
        {
            playerPunch();
        }

        // Zombie is attacking the player.
        if (zombie.GetComponent<Zombie>().isAttacking)
        {
            playerHit();
        }

        // Player is dead.
        if (health <= 0)
        {
            mAnimator.Play("Dead-1");
        }
    }

    // .
    public void playerPunch()
    {
        mAnimator.Play("Punch");
        zombie.GetComponent<Zombie>().zombieHit();
        footSteps.Stop();
    }

    // .
    public void playerHit()
    {
        mAnimator.Play("Hit");
        health -= 10;
    }

}
