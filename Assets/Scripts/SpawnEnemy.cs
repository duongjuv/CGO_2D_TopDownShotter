using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float timeSpawn;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] locationPrefabs;


    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        timer += Time.deltaTime;
        if(timer > timeSpawn)
        {
            timer = 0;
            GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],
                locationPrefabs[Random.Range(0, locationPrefabs.Length)].transform.position, transform.rotation);
        }
    }
}
