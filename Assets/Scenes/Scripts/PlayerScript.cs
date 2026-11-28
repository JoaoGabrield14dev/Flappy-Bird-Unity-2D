using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float forceJump;

    [Header("Audio")]
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hitSound;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeedUp;
    [SerializeField] private float rotationSpeedDown;

    [Space(15)]
    [SerializeField] private float maxAngleZ;
    [SerializeField] private float minAngleZ;

    private Rigidbody2D rb;
    private Animator anim;
    private Quaternion MaxRotation;
    private Quaternion MinRotation;

    private int scoreCurrent;
    private bool death;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        CanvasManager.Instance.UpdateScore(scoreCurrent);

        MaxRotation = Quaternion.Euler(0, 0, maxAngleZ);
        MinRotation = Quaternion.Euler(0, 0, minAngleZ);
    }

    void Update()
    {
        if (CheckInput() && !death)
        {
            rb.linearVelocity = Vector2.up * forceJump;
            AudioManager.Instance.PlaySoundEffect(jumpSound);
        }

        RotationBird();
    }

    bool CheckInput()
    {
        return (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) ||
       (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) ||
       (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame);
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
        if (collision.gameObject.CompareTag("Wall") && !death)
        {
            CanvasManager.Instance.ShowPainelDeath(scoreCurrent);
            AudioManager.Instance.PlaySoundEffect(hitSound);

            SaveManager.Instace.SaveGame();
            ObstacleManager.Instance.StopObstacle();

            anim.enabled = false;
            death = true;       
        }

        if (collision.gameObject.CompareTag("Goal") && !death)
        {
            scoreCurrent++;
            ObstacleManager.Instance.IncreaseDifficulty(scoreCurrent);
            AudioManager.Instance.PlaySoundEffect(scoreSound);
            SaveManager.Instace.CheckMaxScore(scoreCurrent);
            CanvasManager.Instance.UpdateScore(scoreCurrent);
        }
    }
}
