using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenMinXPoint = 1.9f;
    [SerializeField] float screenMaxXPoint = 14.1f;

    // Cached variables
    GameStatus gameStatus;
    Ball ball;

    void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    void Update() {
        Vector2 PaddlePos = new Vector2(
            this.transform.position.x,
            this.transform.position.y
        );
        PaddlePos.x = Mathf.Clamp(GetXPos(), screenMinXPoint, screenMaxXPoint);

        this.transform.position = PaddlePos;
    }

    private float GetXPos() {
        float xPosInUnits = Input.mousePosition.x / Screen.width
            * screenWidthInUnits;

        if(gameStatus.IsAutoplayOn()) {
            xPosInUnits = ball.transform.position.x;
        }

        return xPosInUnits;
    }
}
