using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }
    }
}
