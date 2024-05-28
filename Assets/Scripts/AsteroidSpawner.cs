using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    float maxSpawnRateInSeconds = 5f;

    private void Start()
    {
        Invoke("SpawnAsteroid", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 10f);
    }

    void SpawnAsteroid()
    {
        //bottom-left
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
        //top-right
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

        GameObject asteroid = (GameObject)Instantiate(asteroidPrefab);
        asteroid.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if(maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }
        Invoke("SpawnAsteroid", spawnInNSeconds);
    }

    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if(maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    public void ScheduleAsteroidSpawner()
    {
        Invoke("SpawnAsteroid", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 10f);
    }

    public void UnscheduleAsteroidSpawner()
    {
        CancelInvoke("SpawnAsteroid");
        CancelInvoke("IncreaseSpawnRate");
    }
}