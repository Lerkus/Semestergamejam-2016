using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public enum mode { closeCombat, shotgun }
    public mode attackType = mode.closeCombat;
    public GameObject shotPrefab;
    public float shotgunCd = 1;
    private float lastShot = 1.1f;

    public void attack(Vector2 direction)
    {
        if (attackType == mode.closeCombat)
        {
            closeCombat(direction);
        }
        if (attackType == mode.shotgun)
        {
            shotgun(direction);
        }
    }

    private void closeCombat(Vector2 direction)
    {
        //noch zu implementieren
    }

    private void shotgun(Vector2 direction)
    {
        if (lastShot > shotgunCd)
        {
            GameObject fired;
            int nowShoting = gameObject.GetComponent<PlayerStats>().shotsToFire;
            Vector2 actualDirection = direction - (int)(nowShoting / 2) * new Vector2(direction.y, -direction.x) * gameObject.GetComponent<PlayerStats>().shotgunWidthModifier;
            for (int i = 0; i < nowShoting; i++)
            {
                fired = (GameObject)Instantiate(shotPrefab, gameObject.transform.position, new Quaternion());
                fired.GetComponent<Rigidbody2D>().AddForce(actualDirection * gameObject.GetComponent<PlayerStats>().shotSpeed, ForceMode2D.Impulse);
                actualDirection += new Vector2(direction.y, -direction.x) * gameObject.GetComponent<PlayerStats>().shotgunWidthModifier;
            }
            lastShot = 0;
        }
    }
    public void Update()
    {
        if (lastShot < shotgunCd)
            lastShot += Time.deltaTime;
    }
}
