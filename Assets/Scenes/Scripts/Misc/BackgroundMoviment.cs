using UnityEngine;

public class BackgroundMoviment : MonoBehaviour
{
    [SerializeField] private float speed;

    private MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector2 velocidadeOffset = new Vector3(speed * Time.deltaTime, 0);
        mr.material.mainTextureOffset += velocidadeOffset;
    }
}
