using UnityEngine;
using System.Collections;

public class Mistletoe : MonoBehaviour {
    public int damage = 100;

	void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Snowman")
        {
            Debug.Log("collision");
            coll.gameObject.GetComponent<EnemyStats>().takeDamage(damage);
        }
    }
}
