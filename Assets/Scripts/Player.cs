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
    public int damage = 30;
    public ZombieHealth zombieHealth;
    public Animator mAnimator;
    public Vector2 movement = new Vector2();
    public AudioSource footSteps;

    //.
    private void Start()
    {
        footSteps = GetComponent<AudioSource>();
    }

    private void Update()
    {
        mAnimator = GetComponent<Animator>();

        // Player is walking.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mAnimator.SetTrigger("isWalking");
            footSteps.Play();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * speed * Time.deltaTime, 0);
            transform.Translate(newPosition);
        } else
        {
            mAnimator.SetTrigger("isIdle");
            footSteps.Stop();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * 0 * Time.deltaTime, 0);
            transform.Translate(newPosition);
        }

        // Player is jumping.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mAnimator.SetTrigger("isJumping");
            footSteps.Stop();
            movement.y = Input.GetAxisRaw("Vertical");
            Vector2 newPosition = new Vector2(0, movement.y * 5 * Time.deltaTime);
            transform.Translate(newPosition);
        } else
        {
            mAnimator.SetTrigger("isIdle");
            footSteps.Stop();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * 0 * Time.deltaTime, 0);
            transform.Translate(newPosition);
        }

        // Player is picking.
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mAnimator.SetTrigger("isPicking");
            footSteps.Stop();
            movement.y = Input.GetAxisRaw("Vertical");
            Vector2 newPosition = new Vector2(movement.x * 0 * Time.deltaTime, 0);
            transform.Translate(newPosition);
        }
        else
        {
            mAnimator.SetTrigger("isIdle");
            footSteps.Stop();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * 0 * Time.deltaTime, 0);
            transform.Translate(newPosition);
        }

        // Player is shooting.
        if (Input.GetKey(KeyCode.D))
        {
            mAnimator.SetTrigger("isShooting");
            zombieHealth.ZombieDamage(damage);
        }
        else
        {
            mAnimator.SetTrigger("isIdle");
            footSteps.Stop();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * 0 * Time.deltaTime, 0);
            transform.Translate(newPosition);
        }

        // Player is walking & shooting.
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.B))
        {
            mAnimator.SetTrigger("isWalkingShooting");
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * speed * Time.deltaTime, 0);
            transform.Translate(newPosition);
        }
        else
        {
            mAnimator.SetTrigger("isIdle");
            footSteps.Stop();
            movement.x = Input.GetAxisRaw("Horizontal");
            Vector2 newPosition = new Vector2(movement.x * 0 * Time.deltaTime, 0);
            transform.Translate(newPosition);
        }

    }

}
