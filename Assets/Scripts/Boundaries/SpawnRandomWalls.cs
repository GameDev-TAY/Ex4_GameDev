using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomWalls : MonoBehaviour
{
    [Tooltip("The wall to spawn")] [SerializeField] GameObject prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 5f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 7f;
    private Vector2 screenBounds;

    void Start()
    {
        //Get the Screen boundes from the main camera.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        this.StartCoroutine(SpawnRoutine()); //start spawn.
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns); //randomize the time between spawnes
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3( //randomize the position in the  screen.
                Random.Range(-screenBounds.x, screenBounds.x),
                Random.Range(-screenBounds.y, screenBounds.y),
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f))); //randomize the rotation
            Destroy(newObject, 5f); //destroy the wall after 5 secounds.
        }
    }
}
