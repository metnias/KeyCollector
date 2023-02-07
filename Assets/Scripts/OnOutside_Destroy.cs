using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOutside_Destroy : MonoBehaviour
{
    bool showFlag = false;

    private Renderer r;

    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        if (r.isVisible) showFlag = true;
        else if (showFlag) Destroy(gameObject);
    }
}
