using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject RobotEnemy;
    public int EnemiesToSpawn;
    private int currentEnemies;
    public static int enemiesKilled;
    private float spawnRangeX;
    private float spawnRangeZ;
    public float setMaxSpawnRangeX;
    public float setMaxSpawnRangeZ;
    private float intervalToSpawn;
    public float nextSpawnTimer;

    [HideInInspector]
    public float waveNumber;
    public float maxWaves;
    private float intervalToWave;
    public float nextWaveTimer;
    private bool changedWave = false;


    void Start()
    {
        intervalToWave = nextWaveTimer;
        intervalToSpawn = nextSpawnTimer;
        spawnRangeX = Random.Range(-50, 50);
        spawnRangeZ = Random.Range(-50, 50);
        
    }

    void Update()
    {
        intervalToSpawn -= Time.deltaTime;
        
        if (intervalToSpawn <= 0 && currentEnemies < EnemiesToSpawn && waveNumber < maxWaves)
        {
            Instantiate(RobotEnemy, new Vector3(transform.position.x + spawnRangeX, transform.position.y, transform.position.z + spawnRangeZ), transform.rotation);
            spawnRangeX = Random.Range(-setMaxSpawnRangeX, setMaxSpawnRangeX);
            spawnRangeZ = Random.Range(-setMaxSpawnRangeZ, setMaxSpawnRangeZ);
            intervalToSpawn = nextSpawnTimer;
            currentEnemies++;
        }

        if (enemiesKilled == EnemiesToSpawn)
        {
            if (changedWave == false)
            {
                waveNumber++;
                changedWave = true;
            }
            
            intervalToWave -= Time.deltaTime;

            if (intervalToWave <= 0)
            {
                intervalToWave = nextWaveTimer;
                //intervalToSpawn = nextSpawn;
                changedWave = false;
                currentEnemies = 0;
                enemiesKilled = 0;
                
            }
        }
    }
}