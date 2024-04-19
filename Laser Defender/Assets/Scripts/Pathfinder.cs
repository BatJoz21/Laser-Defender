using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private WavesConfigSO wavesConfig;
    private EnemySpawner enemySpawner;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        wavesConfig = enemySpawner.GetCurrentWave();
        waypoints = wavesConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPaths();
    }

    private void FollowPaths()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPositions = waypoints[waypointIndex].position;
            float delta = wavesConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPositions, delta);
            if (transform.position == targetPositions)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
