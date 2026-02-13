using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Wave currentWave;
    public Transform[] spawnPoint;

    private int enemySpawned = 0;
    private float nextSpawnTime = 0;

    public Wave[] waveConfigs;

    void Update()
    {
        var t = Time.time;
        if (t > nextSpawnTime && enemySpawned < currentWave.enemyCount) 
        {
            Spawn();
            enemySpawned++;
            nextSpawnTime += Time.time + currentWave.spawnInterval;
        }
    }

    void Spawn()
    {
        //animalIndex = Random.Range(0, animalPrefabs.Length);
        //Vector3 spawnPos = new(
        //    Random.Range(-spawnRangeX, spawnRangeX),
        //    transform.position.y,
        //    transform.position.z
        //);
        //Instantiate(
        //    animalPrefabs[animalIndex],
        //    spawnPos,
        //    animalPrefabs[animalIndex].transform.rotation
        //);

        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);

        Instantiate(
            currentWave.enemyPrefabs[enemyIndex], 
            spawnPoint[spawnPointIndex].position, 
            currentWave.enemyPrefabs[enemyIndex].transform.rotation);
    }

}
