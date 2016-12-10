using UnityEngine;
using System.Collections;

public class EnemyStats : Stats {
    public GameObject presentPrefab;

    public override void die()
    {
        if (Random.value < gameObject.GetComponent<PlayerStats>().presentDropChance)
        {
            Instantiate(presentPrefab, transform.position, new Quaternion());
        }
        GameMaster.getGameMaster().GetComponent<WaveManager>().removeActiveEnemy(gameObject);
        GameObject.Destroy(gameObject);
    }
}
