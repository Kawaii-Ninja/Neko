using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public UniversalPlayerData upd;
    [SerializeField] GameObject _cursor;
    [SerializeField] GameObject parentObject;
    public List<Checkers> checkerData = new();

    private void Start()
    {
        SpawnCursor(); // Spawn the cursor.
        upd.canPlay = true;
        if (upd.canPlay)  // Check if the game is playable and spawn the Checker circle.
        {
            upd.isPlaying = true;
            StartCoroutine(SpawnDelay());
        }
    }

    // Get a random object and return the object to spawn next.
    Checkers GetChecker()
    {
        int randomNumber = Random.Range(1, 101); // Get a random number.
        Checkers currentSpawn = null;
        foreach (Checkers checkObj in checkerData) // Iterate over all scriptable objects.
        {
            if (randomNumber <= checkObj._spawnRate) // Check the spawn rate and return the object depending on the spawn rate.
            {
                currentSpawn = checkObj;
                return currentSpawn;
            }
        }
        Debug.Log("No Checker Spawned");
        return null;
    }

    // Instantiate an object in game and make it a child of the parent object.
    void InstantiateChecker()
    {
        Checkers currentSpawnedChecker = GetChecker();

        if (currentSpawnedChecker != null)
        {
            GameObject checker = currentSpawnedChecker._checkerSprit[Random.Range(0, currentSpawnedChecker._checkerSprit.Length)];
            GameObject checkers = Instantiate(checker, new Vector2(Random.Range(-7, 7), 8), Quaternion.identity);
            checkers.transform.SetParent(parentObject.transform);
        }
    }

    // Delay each spawn to allow time before spawning the next object.
    IEnumerator SpawnDelay()
    {
        while (upd.canPlay && !UniversalPlayerData.isGameOver && upd.isPlaying)
        {
            yield return new WaitForSeconds(1f);
            InstantiateChecker();
        }
    }

    // Spawn the cursor object and add components for functionality.
    void SpawnCursor()
    {
        GameObject cursor = Instantiate(_cursor);
        cursor.AddComponent<CursorControl>();
        cursor.AddComponent<PointerTrigger>();
    }
}
