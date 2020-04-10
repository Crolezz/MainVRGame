using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeffSpawner : MonoBehaviour
{
    public Transform navmeshTarget;
    public GameObject prefab;
    float nextSpawn;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextSpawn)
        {
            timer = 0;
            nextSpawn = Random.Range(5, 10);
            GameObject spawned = Instantiate(prefab, transform.position, transform.rotation);

            spawned.GetComponent<JeffEnemyBehavior>().navmeshTarget = navmeshTarget;

        }
    }
}
