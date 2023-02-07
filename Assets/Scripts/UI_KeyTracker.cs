using UnityEngine;
using UnityEngine.UI;

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
