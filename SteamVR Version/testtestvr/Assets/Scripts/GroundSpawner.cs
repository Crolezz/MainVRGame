using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject Boss; 
    public int xPos;
    public int zPos;    
    public int enemyCount = 1;
    int randEnemy;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(DestroyEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while (enemyCount < 6)
        {
            randEnemy = Random.Range(0, 1);
            xPos = Random.Range(-60, 60);         
            zPos = Random.Range(-60, 60);            
            Instantiate(enemies[randEnemy], new Vector3(xPos , 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount += 1;            
        }
    }

    void SpawnBoss()
    {
        Instantiate(Boss, new Vector3(xPos, 0.1f, zPos), Quaternion.identity);
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(10);
        enemyCount -= 6;

        yield return new WaitForSeconds(10);
        if (enemyCount <= 0)
        {
            SpawnBoss();
        }

        Debug.Log("your enemy count is going down" + enemyCount);
    }
}
