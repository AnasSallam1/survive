using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damage = 20;
    public PlayerHealth playerHealth;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Object is Player.
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.PlayerDamage(damage);
        }
    }
}
