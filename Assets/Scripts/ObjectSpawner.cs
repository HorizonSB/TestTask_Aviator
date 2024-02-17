using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;   
    [SerializeField] private GameObject smallMedKit;   
    [SerializeField] private GameObject bigMedKit;   
    [SerializeField] private Transform spawnedObjectsHalder;   
    [SerializeField] private float spawnInterval = 2f;   
    [SerializeField] private float minXSpawn = -425f;      
    [SerializeField] private float maxXSpawn = 425f;

    [SerializeField] private float smallMedKitSpawnInterval = 10f;
    private float timeSinceLastSmallMedKitSpawn = 0f;
    [SerializeField] private float bigMedKitSpawnInterval = 20f;
    private float timeSinceLastBigMedKitSpawn = 0f;

    private float timeSinceLastSpawn = 0f;

    private void Update()
    {
        if (!GameHandler.Instance.IsGamePlaying()) return;


        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject(enemy);

            timeSinceLastSpawn = 0f;
        }

        timeSinceLastSmallMedKitSpawn += Time.deltaTime;

        if (timeSinceLastSmallMedKitSpawn >= smallMedKitSpawnInterval)
        {
            SpawnObject(smallMedKit);

            timeSinceLastSmallMedKitSpawn = 0f;
        }

        timeSinceLastBigMedKitSpawn += Time.deltaTime;

        if (timeSinceLastBigMedKitSpawn >= bigMedKitSpawnInterval)
        {
            SpawnObject(bigMedKit);

            timeSinceLastBigMedKitSpawn = 0f;
        }
    }

    private void SpawnObject(GameObject gameObject)
    {
        float randomX = Random.Range(minXSpawn, maxXSpawn);

        Instantiate(gameObject, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity, spawnedObjectsHalder);
    }
}
