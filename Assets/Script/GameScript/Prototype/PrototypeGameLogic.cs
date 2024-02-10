using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeGameLogic : MonoBehaviour
{
    public List<Checkers> checkerData = new();

    public bool stop = true;

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    Checkers GetChecker()
    {
        int randomNumber = Random.Range(1, 101);
        Checkers currentSpawn;
        foreach (Checkers checkObj in checkerData)
        {
            if (randomNumber <= checkObj._spawnRate)
            {
                currentSpawn = checkObj;
                return currentSpawn;
            }
        }
        Debug.Log("No Checker Spawned");
        return null;
    }

    void InstantiateChecker()
    {
        Checkers currentSpwanedChecker = GetChecker();

        if (currentSpwanedChecker != null)
        {
            GameObject checker = currentSpwanedChecker._checkerSprit[Random.Range(0, currentSpwanedChecker._checkerSprit.Length)];
            Instantiate(checker, new Vector2(Random.Range(-7, 7), 15), Quaternion.identity);
        }
    }


    IEnumerator SpawnDelay()
    {
        while (stop)
        {
            yield return new WaitForSeconds(1f);
            InstantiateChecker();
        }
    }




}
