using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject multishotItemPrefab;
    public GameObject healthItemPrefab;

    float timeToSpawn = 3.0f;
    float minimumInterval = 0.5f;
    float powerupTime = 10.0f;
    
    void Start()
    {
        Invoke("SpawnEnemy", timeToSpawn);
        InvokeRepeating("SpawnPowerup", powerupTime, powerupTime);
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
        Vector2 spawnPosition = new Vector2(Random.Range(-8.2f, 8.2f), transform.position.y);
        Instantiate(multishotItemPrefab, spawnPosition, Quaternion.identity);
    }
}
