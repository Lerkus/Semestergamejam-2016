using UnityEngine;
using System.Collections;

public class Mistletoe : MonoBehaviour {
    public int damage;

	void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Snowman")
        {
            collider.GetComponent<EnemyStats>().takeDamage(damage);
        }
    }
}
