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
        
    }

}
