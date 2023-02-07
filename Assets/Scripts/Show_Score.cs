using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Show_Score : MonoBehaviour
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
