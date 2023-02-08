using UnityEngine;

/// <summary>
/// script for moving player around
/// </summary>
public class Player_Mover : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 8f;

    public bool Grounded() => grounded;

    private float vx;
    private bool moving = false;
    private bool grounded = false;
    private bool lastJumpInput = false;
    private int wantToJump = 0;

    private Rigidbody2D rbody;
    private Animator ani;
    private SpriteRenderer spr;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
        rbody.gravityScale = 4f;
        spr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        vx = 0f; moving = false;
        if (Input.GetKey(KeyCode.RightArrow)) { vx = speed; moving = true; }
        else if (Input.GetKey(KeyCode.LeftArrow)) { vx = -speed; moving = true; }
        if (Input.GetKey(KeyCode.Z))
        {
            if (!lastJumpInput) wantToJump = 5;
            lastJumpInput = true;
        }
        else lastJumpInput = false;

        float s = Mathf.Max(Mathf.Abs(vx / speed), rbody.velocity.y / jumpPower);
        s = Mathf.Clamp01(s * 0.8f + 0.2f);
        ani.speed = s;
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
        if (moving) spr.flipX = vx < 0f;
        if (wantToJump > 0)
        {
            wantToJump--;
            if (grounded)
            {
                wantToJump = 0;
                rbody.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platforms")
            && rbody.velocity.y == 0f) // to prevent "swiming up" inside platforms
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
            grounded = false;
    }
}
