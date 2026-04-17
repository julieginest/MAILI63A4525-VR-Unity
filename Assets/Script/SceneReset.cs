using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
    [SerializeField] private KeyCode resetKey = KeyCode.Backspace;

    private void Update()
    {
        if (Input.GetKeyDown(resetKey))
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}