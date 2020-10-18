using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
        Cursor.visible = false;
    }

    public void LoadStartMenuScene() {
        FindObjectOfType<GameStatus>().ResetScore();
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    public void Quit() {
        Application.Quit();
    }
}
