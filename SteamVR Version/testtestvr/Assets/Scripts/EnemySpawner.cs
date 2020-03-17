using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int xPos;
    public int zPos;
    public int enemyCount;
    int randEnemy;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while(enemyCount < 10)
        {
            randEnemy = Random.Range(0, 2);
            xPos = Random.Range(-75, 75);
            zPos = Random.Range(-95, 95);
            Instantiate(enemies[randEnemy], new Vector3(xPos,20, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount += 1; 
        }
       

    }
}
