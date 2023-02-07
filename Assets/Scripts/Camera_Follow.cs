using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject player;
    private Player_Mover mover;
    private bool right = true;

    public float vertPos = 2f;
    public float vertCap = 3f;
    public float horzPos = 2f;
    public float horzTurn = 4f;
    public float lerpCapSpeed = 0.1f;


    void Start()
    {
        mover = player.GetComponent<Player_Mover>();
    }

    void Update()
    {
        Vector3 relative = player.transform.position - transform.position;
        Vector3 target = Vector3.zero;
        // Vertical
        if (mover != null)
        {
            bool grounded = mover.Grounded();
            if (grounded) // platform snap
            {
                target.y = vertPos + relative.y;
            }
            else // follow
            {
                if (relative.y > vertCap)
                {
                    target.y = relative.y - vertCap;
                }
                else if (relative.y < -vertCap)
                {
                    target.y = relative.y + vertCap;
                }
            }
        }

        
        // Horizontal
        if (right)
        {
            if (relative.x > -horzPos) target.x = relative.x + horzPos;
            else if (relative.x < -horzTurn) right = false;
        }
        else
        {
            if (relative.x < horzPos) target.x = relative.x - horzPos;
            else if (relative.x > horzTurn) right = true;
        }

        // Apply target
        // target = Vector3.Lerp(Vector3.zero, target, lerpSpeed);
        target.x = Mathf.Clamp(target.x, -lerpCapSpeed, lerpCapSpeed); // horizontal cap
        target.y = Mathf.Min(target.y, lerpCapSpeed); // rising cap
        transform.Translate(target);
    }
}
