using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public Vector2 minBounds = new Vector2(0, 0);
    public Vector2 maxBounds = new Vector2(10, 10);
    public float distanceToMid = 10;
    public float timeDelayBetweenWaves = 60;
    private Coroutine timer;
    private int actualWave = 0;
    public int maxWave = 5;
    public GameObject EnemyPrefab;
    public Camera mainCam;
    public int[] amountOfEnemiesToSpawn;
    public int difficulty = 10;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public string finishedScene = "test Lerkus";


    public void Start()
    {
        amountOfEnemiesToSpawn = new int[maxWave];
        for (int i = 0; i < maxWave; i++)
        {
            amountOfEnemiesToSpawn[i] = Mathf.RoundToInt(Random.value * (float)(difficulty));
        }
        var player = Instantiate(GameMaster.getGameMaster().playerPrefab, (maxBounds + minBounds)/2, new Quaternion()) as GameObject;
        GameMaster.player = player;
        mainCam.transform.parent = GameMaster.player.GetComponentInChildren<Body>().gameObject.transform;
        nextWave();
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
            timer = StartCoroutine(waitingForNextWave());
            actualWave++;
        }
    }

    private void spawnWave()
    {
        Vector2 placeOfSpawning;
        for (int i = 0; i < amountOfEnemiesToSpawn[actualWave]; i++)
        {
            placeOfSpawning = minBounds + new Vector2((maxBounds - minBounds).x * Mathf.RoundToInt(Random.value), (maxBounds - minBounds).y * Mathf.RoundToInt(Random.value));
            GameObject spawned = (GameObject)Instantiate(EnemyPrefab, placeOfSpawning, new Quaternion());
            spawned.GetComponent<Snowman>().target = GameMaster.player.GetComponentInChildren<Body>().gameObject.transform;
            activeEnemies.Add(spawned);
        }
    }

    public void Update()
    {
        if(actualWave == maxWave && activeEnemies.Count == 0)
        {
            SceneManager.LoadScene(finishedScene);
        }
    }

    public void removeActiveEnemy(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
    }
}
