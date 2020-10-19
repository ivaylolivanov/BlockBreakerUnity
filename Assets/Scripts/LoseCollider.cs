using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        GameStatus currentStatus = FindObjectOfType<GameStatus>();

        if(currentStatus.Resurect()) {
            LoadCurrentScene();
        }
        else {
            SceneManager.LoadScene("GameOver");
            Cursor.visible = true;
        }
    }

    private void LoadCurrentScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
