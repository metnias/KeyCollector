using UnityEngine;

public class Item_Bops : MonoBehaviour
{
    public float bopSpeed = 2f;
    public float bopHeight = 2f;

    private float posY;
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
            posY + Mathf.Sin(timer * bopSpeed / 200f) * bopHeight / 50f,
            transform.position.z);
    }
}
