using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance { get; private set; }

    [SerializeField] private Transform obstacleSpaw;
    [SerializeField] private GameObject obstacleObject;

    [SerializeField] private float cooldownSpaw;

    private float time;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    void Update()
    {
        Cooldown();
    }

    void Cooldown()
    {
        time += Time.deltaTime;
        if (time > cooldownSpaw)
        {
            SpawObstacle();
            time = 0;
        }
    }

    void SpawObstacle()
    {
        Instantiate(obstacleObject, SpawObstaclePos(), Quaternion.identity);
    }

    Vector3 SpawObstaclePos()
    {
        return new Vector3(obstacleSpaw.position.x, Random.Range(-2.5f, 2.75f), 3);
    }

    public void StopObstacle()
    {
        WallMoviment[] allObstacles = FindObjectsByType<WallMoviment>();
        BackgroundMoviment[] allBgMov = FindObjectsByType<BackgroundMoviment>();

        foreach (var ao in allObstacles)
            ao.speed = 0;

        foreach (var bg in allBgMov) 
            bg.enabled = false;

        enabled = false;
    }
}
