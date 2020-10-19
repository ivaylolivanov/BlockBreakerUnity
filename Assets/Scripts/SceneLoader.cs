using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] public string winScreenName = "WinScreen";
    [SerializeField] public float winScreenScorePosX;
    [SerializeField] public float winScreenScorePosY;

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
        Cursor.visible = false;

        string nextSceneName = SceneManager.GetSceneByBuildIndex(
            currentSceneIndex
        ).name;
        if(nextSceneName == winScreenName) {
            ReorderWinScreen();
        }
    }

    public void LoadStartMenuScene() {
        FindObjectOfType<GameStatus>().ResetScore();
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    public void Quit() {
        Application.Quit();
    }

    private void ReorderWinScreen() {
        TextMeshProUGUI scoreText = FindObjectOfType<TextMeshProUGUI>();

        scoreText.transform.position = new Vector3(
            winScreenScorePosX,
            winScreenScorePosY,
            0
        );

        Cursor.visible = true;
    }
}
