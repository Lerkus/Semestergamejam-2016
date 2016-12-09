using UnityEngine;
using System.Collections;
using System;

public class EnemyStats : Stats {

    public override void die()
    {
        GameObject.Destroy(gameObject);
    }
}
