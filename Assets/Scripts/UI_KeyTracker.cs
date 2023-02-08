using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows whether this key is collected or not
/// </summary>
public class UI_KeyTracker : MonoBehaviour
{
    public int keyNum = 0;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.enabled = GameManager.Instance().HasKey(keyNum);
    }
}
