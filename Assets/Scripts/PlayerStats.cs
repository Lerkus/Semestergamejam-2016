using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : Stats {
    [Header("Attack Stats")]
    public float attackCoolDown = 0.5f;
    public int shotsToFire = 5;
    public float shotSpeed = 10;
    public float shotgunWidthModifier = 0.1f;
    public float shotDmg = 1;
    public float mistelDmg = 1;
    public float dmgTakenMultiplier = 1;
    public float invicibleTime = 0.1f;
    public float presentDropChance = 0.2f;

    public override void die()
    {
        SceneManager.LoadScene("Scenes/Main");
    }
}
