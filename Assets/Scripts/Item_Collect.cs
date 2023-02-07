using UnityEngine;

public class Item_Collect : MonoBehaviour
{
    public int keyNum = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance().CollectKey(keyNum);
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }
}
