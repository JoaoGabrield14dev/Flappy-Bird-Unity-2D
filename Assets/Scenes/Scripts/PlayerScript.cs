using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float forceJump;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanvasManager.Instance.UpdateScore(SaveManager.Instace.Score);
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
            SaveManager.Instace.Deaths++;
            SaveManager.Instace.SaveGame();
            print("Game Over");
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            SaveManager.Instace.Score++;
            CanvasManager.Instance.UpdateScore(SaveManager.Instace.Score);
        }
    }
}
