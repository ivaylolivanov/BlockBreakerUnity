using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Configuration parameters
    [Range(0f, 10f)] [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public int pointsPerBlockDestroyed = 30;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public bool autoplay = false;

    // State variables
    private int currentScore = 0;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if(gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore() {
        currentScore += pointsPerBlockDestroyed;
        DisplayScore();
    }

    public void ResetScore() {
        Destroy(gameObject);
    }

    public bool IsAutoplayOn() {
        return autoplay;
    }

    private void Start() {
        DisplayScore();
    }

    private void Update() {
        Time.timeScale = gameSpeed;
    }

    private void DisplayScore() {
        scoreText.text = currentScore.ToString();
    }
}
