using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float forceJump;

    private Rigidbody2D rb;

    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanvasManager.Instance.UpdateScore(score);
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * forceJump;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            print("Game Over");
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            score++;
            CanvasManager.Instance.UpdateScore(score);
        }
    }
}
