using UnityEngine;

/// <summary>
/// Enemy patrolling on platform script
/// </summary>
public class Enemy_Patrol : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rbody;
    private Animator ani;
    private SpriteRenderer spr;

    private bool left = true;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
        rbody.gravityScale = 4f;
        spr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        spr.flipX = left;
        ani.speed = speed * 0.1f;
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(left ? -speed : speed, rbody.velocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Platforms")) return;
        // if the trigger leaves the platform:
        // it's about to fall, so turn back
        left = !left;
    }
}
