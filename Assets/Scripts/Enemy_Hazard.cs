using UnityEngine;

/// <summary>
/// Enemy collsion script
/// </summary>
public class Enemy_Hazard : MonoBehaviour
{
    public int penalty = 200;
    public float flingPower = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        GameManager.Instance().GameOver();
        collision.gameObject.SetActive(false);

        // originally planned to give score penalty upon hit, but
        // decided not to after adding bullets
        /*
        GameManager.Instance().ReduceScore(penalty);
        // Flings player away
        var player = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector3 fling = player.transform.position - transform.position;
        fling.z = 0f; // don't fling z wise
        fling = fling.normalized;
        fling.y = Mathf.Max(fling.y, 0f) + 0.2f; // always fling slightly upwards
        fling *= flingPower;
        player.AddForce(fling, ForceMode2D.Impulse);
        */
    }
}
