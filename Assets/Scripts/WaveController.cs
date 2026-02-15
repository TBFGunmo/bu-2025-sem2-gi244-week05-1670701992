using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Wave currentWave;
    public Transform[] spawnPoint;

    private int enemySpawned = 0;
    private float nextSpawnTime = 0;
    private float checkEndSpawnTime = 0;

    

    void Update()
    {
        var t = Time.time;
        if (t > nextSpawnTime && enemySpawned < currentWave.enemyCount) 
        {
            Spawn();
            enemySpawned++;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            /*print(nextSpawnTime);
            print(Time.time);
            print(currentWave.spawnInterval);*/
        }
    }

    public void ChangeWave(Wave wave)
    {
        print("change wave");
        currentWave = wave;

        enemySpawned = 0;
        nextSpawnTime = Time.time;

        checkEndSpawnTime = Time.time + currentWave.waveInterval;

    }

    public bool IsCompleted() 
    {
        /*print(checkEndSpawnTime);
        print(Time.time);*/
        return (enemySpawned >= currentWave.enemyCount) && Time.time > checkEndSpawnTime;
    }


    void Spawn()
    {
        /*animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new(
            Random.Range(-spawnRangeX, spawnRangeX),
            transform.position.y,
            transform.position.z
        );
        Instantiate(
            animalPrefabs[animalIndex],
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation
        );*/

        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);

        Instantiate(
            currentWave.enemyPrefabs[enemyIndex], 
            spawnPoint[spawnPointIndex].position, 
            currentWave.enemyPrefabs[enemyIndex].transform.rotation);

        print("spawn" + currentWave.enemyPrefabs[enemyIndex] + Time.time);

    }

}
