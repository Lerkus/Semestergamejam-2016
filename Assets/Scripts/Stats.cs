using UnityEngine;
using System.Collections;

public abstract class Stats : MonoBehaviour {

    public float actualHealth = 100;
    public float maxHealth = 100;
    public float speed = 5;
    public float strenght = 1;

    public void takeDamage(float damage)
    {
        actualHealth -= damage;
        if(actualHealth <= 0)
        {
            die();
        }
    }

    public abstract void die();
}
