using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public int damage = 1;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Enemy")
        {
            coll.collider.GetComponent<EnemyStats>().takeDamage(damage);
        }
    }

}
