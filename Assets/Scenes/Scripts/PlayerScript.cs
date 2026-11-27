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
    private Quaternion MaxRotation;
    private Quaternion MinRotation;

    private int scoreCurrent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanvasManager.Instance.UpdateScore(scoreCurrent);

        MaxRotation = Quaternion.Euler(0, 0, maxAngleZ);
        MinRotation = Quaternion.Euler(0, 0, minAngleZ);
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
            transform.rotation = Quaternion.Lerp(transform.rotation, MaxRotation, rotationSpeedUp * Time.deltaTime);
        }
        else if (rb.linearVelocity.y < -0.1f) // It´s Coming Down
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, MinRotation, rotationSpeedDown * Time.deltaTime);
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
            scoreCurrent++;
            SaveManager.Instace.CheckMaxScore(scoreCurrent);
            CanvasManager.Instance.UpdateScore(scoreCurrent);
        }
    }
}
