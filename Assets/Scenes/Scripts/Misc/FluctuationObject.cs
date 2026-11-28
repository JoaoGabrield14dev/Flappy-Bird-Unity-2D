using UnityEngine;

public class FluctuationObject : MonoBehaviour
{
    [SerializeField] private float maxPos;
    [SerializeField] private float minPos;
    [SerializeField] private float speed;

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;
        float fluctuation = Mathf.Lerp(minPos, maxPos, t);

        transform.localPosition = new Vector3(transform.localPosition.x, fluctuation, transform.localPosition.z);
    }
}
