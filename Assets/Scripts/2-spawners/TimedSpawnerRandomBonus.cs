﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawnerRandomBonus : MonoBehaviour
{
    [Tooltip("The Object to spawn")] [SerializeField] GameObject prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 20f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 40f;
    private Vector2 screenBounds;

    void Start()
    {
        //Get the Screen boundes from the main camera.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //start spawn.
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            //randomize the time between spawns
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns); 
            yield return new WaitForSeconds(timeBetweenSpawns);

            //set posoition randomly in the screen.
            Vector3 positionOfSpawnedObject = new Vector3(
                Random.Range(-screenBounds.x, screenBounds.x),
                Random.Range(-screenBounds.y, screenBounds.y),
                transform.position.z);
           
            //spawn the objects.
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
        }
    }
}
