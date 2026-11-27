using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float forceJump;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeedUp;
    [SerializeField] private float rotationSpeedDown;

    [Space(15)]
    [SerializeField] private float maxAngleZ;
    [SerializeField] private float minAngleZ;

    private Rigidbody2D rb;
    private Quaternion MaxAngle;
    private Quaternion MinAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanvasManager.Instance.UpdateScore(SaveManager.Instace.Score);

        MaxAngle = Quaternion.Euler(0, 0, maxAngleZ);
        MinAngle = Quaternion.Euler(0, 0, minAngleZ);
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * forceJump;
        }

        RotationBird();
    }

    void RotationBird()
    {
        if (rb.linearVelocity.y > 0.1f) // It´s going up
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, MaxAngle, rotationSpeedUp * Time.deltaTime);
        }
        else if (rb.linearVelocity.y < -0.1f) // It´s Coming Down
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, MinAngle, rotationSpeedDown * Time.deltaTime);
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
