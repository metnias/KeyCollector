using UnityEngine;

/// <summary>
/// Animation for this going up and down gently
/// </summary>
public class Item_Bops : MonoBehaviour
{
    public float bopSpeed = 2f;
    public float bopHeight = 2f;

    private float posY; // saved posY; so this assumes posY never changes.
    private int timer;

    void Start()
    {
        posY = transform.position.y;
        timer = 0;
    }

    void Update()
    {
        timer++;
        transform.position = new Vector3(transform.position.x,
            posY + Mathf.Sin(timer * bopSpeed / 200f) * bopHeight / 50f, // sine function
            transform.position.z);
    }
}
