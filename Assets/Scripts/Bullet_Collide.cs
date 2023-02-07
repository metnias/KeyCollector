using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collide : MonoBehaviour
{
    private bool alive;

    private void Start()
    {
        alive = true;
        Invoke(nameof(DestroySelf), 5f); // destroy if this goes outside map
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alive) return; // in case this collides with something in mid-explosion
        if (collision.gameObject.CompareTag("Enemies"))
        {
            // destroy enemy
            Destroy(collision.gameObject);
            GameManager.Instance().EnemyKilled();
        }
        else if (!collision.gameObject.CompareTag("Platforms")) // colliding with platform also kills bullet
            return; // colliding with unrelevent
        GetComponent<Animator>().speed = 2f; // play explosion animation
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; // stop movement
        Invoke(nameof(DestroySelf), 0.25f);
        alive = false;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}
