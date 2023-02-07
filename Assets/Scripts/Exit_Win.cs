using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        for (int i = 0; i < 3; i++)
            if (!GameManager.Instance().HasKey(i)) return;
        GameManager.Instance().GameWin();
    }
}
