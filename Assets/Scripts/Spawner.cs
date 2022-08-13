using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // public GameObject multishotItemPrefab;
    // public GameObject healthItemPrefab;
    public GameObject[] powerUps;

    float timeToSpawn = 3.0f;
    float minimumInterval = 0.5f;
    float powerupTime = 10.0f;
    
    void Start()
    {
        Invoke("SpawnEnemy", timeToSpawn);
        Invoke("SpawnPowerup", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy() {
        Vector2 spawnPosition = new Vector2(Random.Range(-8.0f, 8.0f), transform.position.y);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Invoke("SpawnEnemy", timeToSpawn);
        if (timeToSpawn > minimumInterval) {
            timeToSpawn -= 0.05f;
        }
    }

    void SpawnPowerup() {
        int randomSpawn = Random.Range(0, powerUps.Length);
        Vector2 spawnPosition = new Vector2(Random.Range(-8.2f, 8.2f), transform.position.y);
        Instantiate(powerUps[randomSpawn], spawnPosition, Quaternion.identity);
        Invoke("SpawnPowerup", Random.Range(3.0f, 15.0f));
    }
}
