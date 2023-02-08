using UnityEngine;

/// <summary>
/// Camera following player script
/// </summary>
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

        // Camera movements is *fun*
        // This time I'm using Super Mario World's method.
        // Vertical: Platform Snapping & Camera Window
        if (mover != null)
        {
            bool grounded = mover.Grounded();
            if (grounded) // Platform Snapping
            {
                target.y = vertPos + relative.y;
            }
            else // Camera Window
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

        // Horizontal: Dual Forward Focus w/ threshold triggered
        if (right)
        {
            if (relative.x > -horzPos) target.x = relative.x + horzPos; // Forward Focus
            else if (relative.x < -horzTurn) right = false; // threshold trigger
        }
        else
        {
            if (relative.x < horzPos) target.x = relative.x - horzPos;
            else if (relative.x > horzTurn) right = true;
        }

        // Apply target
        // target = Vector3.Lerp(Vector3.zero, target, lerpSpeed);
        target.x = Mathf.Clamp(target.x, -lerpCapSpeed, lerpCapSpeed); // Horizontal Speed Cap
        target.y = Mathf.Min(target.y, lerpCapSpeed); // Vertical Upward Speed Cap
                                                      // (No downward speed cap as that may result unfair situations)
        transform.Translate(target);
    }
}
