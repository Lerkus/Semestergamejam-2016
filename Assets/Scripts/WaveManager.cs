using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public Vector2 minBounds = new Vector2(0, 0);
    public Vector2 maxBounds = new Vector2(10, 10);
    public float distanceToMid = 10;
    public float timeDelayBetweenWaves = 60;
    private IEnumerator timer;
    private int actualWave = 0;
    public int maxWave = 5;
    public GameObject EnemyPrefab;
    public List<int> amountOfEnemiesToSpawn;
    public int difficulty = 10;

    public void Start()
    {
        amountOfEnemiesToSpawn = new List<int>(maxWave);

    }

    private IEnumerator waitingForNextWave()
    {
        yield return new WaitForSeconds(timeDelayBetweenWaves);
        StopCoroutine(timer);
        nextWave();
    }

    public void nextWave()
    {
        if (actualWave < maxWave)
        {
            spawnWave();
            StartCoroutine(waitingForNextWave());
            actualWave++;
        }
    }

    private void spawnWave()
    {
        Vector2 placeOfSpawning;
        for (int i = 0; i < amountOfEnemiesToSpawn[actualWave]; i++)
        {
            placeOfSpawning = minBounds + (maxBounds - minBounds) * Mathf.RoundToInt(Random.value);
            Instantiate(EnemyPrefab, placeOfSpawning, new Quaternion());
        }
    }
}
