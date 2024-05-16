using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform playerTransform;
    public bool isChasing;
    public bool isAttacking;
    public float chaseDistance;
    public float attackDistance;

    public Animator mAnimator;
    public AudioSource walking;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        chaseDistance = 20;
        attackDistance = 2;

        // .
        if ((Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            && (Vector2.Distance(transform.position, playerTransform.position) > attackDistance))
        {
            isChasing = true;

            if (isChasing)
            {
                mAnimator.SetTrigger("isWalking");
                walking.Play();

                if (transform.position.x > playerTransform.position.x)
                {
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }

            }
        }

        // .
        if (Vector2.Distance(transform.position, playerTransform.position) < attackDistance)
        {
            isAttacking = true;

            if (isAttacking)
            {
                mAnimator.SetTrigger("isAttacking");

                if (transform.position.x > playerTransform.position.x)
                {
                    transform.position += Vector3.left * 0 * Time.deltaTime;
                }

            }
        }

    }

}