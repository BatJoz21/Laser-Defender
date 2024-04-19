using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WavesConfigSO> wavesConfig;
    [SerializeField] private float timeBetweenWaves = 1.0f;

    private WavesConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WavesConfigSO GetCurrentWave() { return currentWave; }

    private IEnumerator SpawnEnemyWaves()
    {
        for (int i = 0; i < wavesConfig.Count; i++)
        {
            currentWave = wavesConfig[i];
            for (int j = 0; j < currentWave.GetEnemyCount(); j++)
            {
                Instantiate(currentWave.GetEnemyPrefab(j), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSecondsRealtime(timeBetweenWaves);
        }
    }
}
