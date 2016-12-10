using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public enum mode { closeCombat, shotgun }
    public mode attackType = mode.shotgun;
    public GameObject shotPrefab;
    public float shotgunCd = 1;
    private float lastShot = 1.1f;

    private float swapCd = .5f;
    private float lastSwap = 1.1f;
    private GameObject mistletoe;
    public GameObject mistletoePrefab;

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
            int nowShoting = GameMaster.getGameMaster().GetComponent<PlayerStats>().shotsToFire;
            Vector2 actualDirection = direction - (int)(nowShoting / 2) * new Vector2(direction.y, -direction.x) * GameMaster.getGameMaster().GetComponent<PlayerStats>().shotgunWidthModifier;
            for (int i = 0; i < nowShoting; i++)
            {
                fired = (GameObject)Instantiate(shotPrefab, gameObject.transform.position, new Quaternion());
                fired.GetComponent<Rigidbody2D>().AddForce(actualDirection * GameMaster.getGameMaster().GetComponent<PlayerStats>().shotSpeed, ForceMode2D.Impulse);
                actualDirection += new Vector2(direction.y, -direction.x) * GameMaster.getGameMaster().GetComponent<PlayerStats>().shotgunWidthModifier;
            }
            lastShot = 0;
        }
    }
    public void Update()
    {
        if (lastShot < shotgunCd)
            lastShot += Time.deltaTime;

        if (lastSwap < swapCd)
            lastSwap += Time.deltaTime;
    }

    public void switchWeapon()
    {
        if (lastSwap > swapCd) {
            if (attackType == mode.shotgun)
            {
                attackType = mode.closeCombat;
                mistletoe = (GameObject)Instantiate(mistletoePrefab, gameObject.transform.position + (Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z + 90) * Vector2.right).normalized * -1, gameObject.transform.rotation);
                mistletoe.transform.parent = this.gameObject.transform;
            }
            else if (attackType == mode.closeCombat)
            {
                attackType = mode.shotgun;
                GameObject.Destroy(mistletoe);
                mistletoe = null;
            }

            lastSwap = 0;
        }
    }
}
