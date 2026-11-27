using UnityEngine;

public class WallMoviment : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed;
    }
}
