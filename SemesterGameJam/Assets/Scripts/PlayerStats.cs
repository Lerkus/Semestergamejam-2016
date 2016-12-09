using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : Stats {
    [Header("Attack Stats")]
    public float attackCoolDown = 0.5f;
    public int shotsToFire = 5;
    public float shotSpeed = 10;
    public float shotgunWidthModifier = 0.1f;

    public override void die()
    {
        SceneManager.LoadScene("Scenes/Main");
    }
}
