using UnityEngine;

/// <summary>
/// Shoots bullet
/// </summary>
public class Player_Shoot : MonoBehaviour
{
    public GameObject bullet;
    public int cooldown = 50;

    private SpriteRenderer spr;
    private bool lastPressed = false;
    private int wantToShoot = 0;
    private int delay = 0;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (!lastPressed) wantToShoot = 5;
            lastPressed = true;
        }
        else lastPressed = false;
    }

    private void FixedUpdate()
    {
        if (delay > 0) delay--;
        if (wantToShoot > 0)
        {
            wantToShoot--;
            if (delay < 1)
            {
                wantToShoot = 0;
                delay = wantToShoot;
                var b = Instantiate(bullet);
                b.transform.position = transform.position;
                b.GetComponent<Bullet_Move>().Fire(!spr.flipX);
                // use player sprite direction for shoot direction
            }
        }

    }

}
