using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    public enum mode {closeCombat, shotgun}
    public mode attackType = mode.closeCombat;


    public void attack(Vector2 direction)
    {
        if(attackType == mode.closeCombat)
        {
            closeCombat(direction);
        }
        if(attackType == mode.shotgun)
        {
            shotgun(direction);
        }
    }

    private void closeCombat(Vector2 direction)
    {

    }

    private void shotgun(Vector2 direction)
    {

    }
}
