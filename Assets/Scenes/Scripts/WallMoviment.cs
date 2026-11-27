using UnityEngine;

public class WallMoviment : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        Destroy(gameObject, 6);
    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed;
    }
}
