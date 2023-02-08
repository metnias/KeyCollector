using UnityEngine;

public class Exit_Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.Instance().CanWin()) return;
        if (!collision.gameObject.CompareTag("Player")) return;
        GameManager.Instance().GameWin();
    }
}
