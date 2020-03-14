using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies; 
    public GameObject[] spawnPoints;
    public float startWait;
    public float spawnWait;
    public bool stop;
    public Vector3 spawnValues;
    public float Yvalue;
    public float leastWait;
    public float mostWait; 

    int randEnemy; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(leastWait, mostWait);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startWait); 

        while(!stop)
        {
            randEnemy = Random.Range(0,2); 
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
