using UnityEngine;
using System.Collections;

public class PlayerProgress : MonoBehaviour {

    [Header("Attack Stats")]
    public static float attackCoolDown = 0.5f;
    public static int shotsToFire = 5;
    public static float shotSpeed = 10;
    public static float shotgunWidthModifier = 0.1f;
    public static float shotDmg = 1;
    public static float mistelDmg = 1;
    public static float dmgTakenMultiplier = 1;
    public static float invicibleTime = 0.1f;
    public static float presentDropChance = 0.2f;
    public static float walkSpeed= 20;
    public static float mistleSize = 0.2f;
    public static float maxHealth = 10;
}
