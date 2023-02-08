using TMPro;
using UnityEngine;

/// <summary>
/// Shows enemy counter to TMP
/// </summary>
public class Show_Enemies : MonoBehaviour
{
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        var e = GameManager.Instance().Enemies();
        string s = e switch
        {
            1 => "Enemy Left: 1",
            0 => "Enemies Cleared!",
            _ => $"Enemies Left: {e}",
        };
        text.text = s;
    }
}
