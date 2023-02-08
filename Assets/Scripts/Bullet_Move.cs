using UnityEngine;

/// <summary>
/// Bullet moving script
/// </summary>
public class Bullet_Move : MonoBehaviour
{
    public float fireSpeed = 100f;

    private Rigidbody2D rbody;
    private Animator ani;
    private bool right;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
        rbody.gravityScale = 0f;
        ani = GetComponent<Animator>();
        ani.speed = 0f; // freeze animation
    }

    public void Fire(bool right)
    {
        rbody.velocity = right ? Vector2.right : Vector2.left;
        rbody.velocity *= fireSpeed;
        this.right = right;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, right ? 6f : -6f)); // spin
    }
}
