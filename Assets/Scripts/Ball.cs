using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] public Paddle paddle;
    [SerializeField] public float xLaunch;
    [SerializeField] public float yLaunch;
    [SerializeField] public AudioClip[] sounds;
    [SerializeField] public float randomFactor;

    // State
    private Vector2 paddle2BallGap = new Vector2();
    private bool isLaunched;
    private Rigidbody2D rigidbody2D;

    // Cache
    AudioSource audioSource;

    void Start() {
        paddle2BallGap = transform.position - paddle.transform.position;

        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        isLaunched = false;
    }

    void Update() {
        if(! isLaunched) {
            Stick2Paddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0)) {
            rigidbody2D.velocity = new Vector2(xLaunch, yLaunch);
            isLaunched = true;
        }
    }

    private void Stick2Paddle() {
        Vector2 paddlePos = new Vector2(
            paddle.transform.position.x,
            paddle.transform.position.y
        );
        this.transform.position = paddlePos + paddle2BallGap;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomFactor),
            Random.Range(0, randomFactor)
        );
        if(isLaunched) {
            AudioClip clip = sounds[0];
            audioSource.PlayOneShot(clip);

            rigidbody2D.velocity += velocityTweak;
        }
    }
}
