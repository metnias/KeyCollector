using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hazard : MonoBehaviour
{
    public int penalty = 200;
    public float flingPower = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        GameManager.Instance().ReduceScore(penalty);
        var player = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector3 fling = player.transform.position - transform.position;
        fling.z = 0f;
        fling = fling.normalized * flingPower;
        fling.y += 10f;
        player.AddForce(fling, ForceMode2D.Impulse);
    }
}
