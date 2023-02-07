using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Show_Counter : MonoBehaviour
{
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = $"Score: {GameManager.Instance().Score() * 10}";
    }
}
