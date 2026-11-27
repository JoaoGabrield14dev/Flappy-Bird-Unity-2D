using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private Transform obstacleSpaw;
    [SerializeField] private GameObject obstacleObject;

    [SerializeField] private float cooldownSpaw;

    private float time;

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
}
