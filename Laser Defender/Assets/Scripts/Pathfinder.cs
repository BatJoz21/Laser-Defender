using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private WavesConfigSO wavesConfig;

    private List<Transform> waypoints;
    private int waypointIndex = 0;

    void Start()
    {
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
