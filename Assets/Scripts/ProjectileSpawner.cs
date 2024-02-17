using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public float spawnInterval = 2f; 

    private float timeSinceLastSpawn = 0f;
    private Transform spawnedObjectsHandler;

    private void Start()
    {
        spawnedObjectsHandler = GameObject.FindGameObjectWithTag("SpawnedObjectsHandler").transform;
    }

    private void Update()
    {
        if (!GameHandler.Instance.IsGamePlaying()) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();

            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnDirection = transform.up;

        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity, spawnedObjectsHandler);

        spawnedObject.transform.up = -spawnDirection;
    }
}
