using TMPro;
using UnityEngine;

/// <summary>
/// Shows the game score to TMP
/// </summary>
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
