using UnityEngine;
using System.Collections;

public class Mistletoe : MonoBehaviour {
    public int damage = 100;

	void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Snowman")
        {
            Debug.Log("collision");
            collider.GetComponent<EnemyStats>().takeDamage(damage);
        }
    }
}
