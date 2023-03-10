using System;
using UnityEngine;

/// <summary>
/// Spawns a prefab where you've clicked
/// </summary>
public class OnClick_SpawnPrefab : MonoBehaviour
{
    public GameObject newPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward);
            pos.z = -5f;
            GameObject newGameObject = Instantiate(newPrefab) as GameObject;
            newGameObject.transform.position = pos;
        }
    }
}
