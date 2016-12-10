using UnityEngine;
using System.Collections;

public abstract class Stats : MonoBehaviour {

    public int health = 100;
    public int speed = 5;
    public int strenght = 1;

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            die();
        }
    }

    public abstract void die();
}
