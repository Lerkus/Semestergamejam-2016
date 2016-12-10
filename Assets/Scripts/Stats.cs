using UnityEngine;
using System.Collections;

public abstract class Stats : MonoBehaviour {

    public float health = 100;
    public float speed = 5;
    public float strenght = 1;

    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            die();
        }
    }

    public abstract void die();
}
