using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_ChangeScene : MonoBehaviour
{
    public int sceneNumber = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SwitchScene();
    }

    private void OnMouseDown()
    {
        SwitchScene();
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
