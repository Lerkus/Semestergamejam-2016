using UnityEngine;
using System.Collections;

public class EnemyStats : Stats {
    public GameObject presentPrefab;
    public float dropChance = 0.3f;

    public override void die()
    {
        if (Random.value < dropChance)
        {
            Instantiate(presentPrefab, transform.position, new Quaternion());
        }
        GameMaster.getGameMaster().GetComponent<WaveManager>().removeActiveEnemy(gameObject);
        GameObject.Destroy(gameObject);
    }
}
