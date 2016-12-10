using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public int damage = 1;
    public float timeToLive = 0.2f;
    private Coroutine timer;


    public void Awake()
    {
        timer = StartCoroutine(timeOut());
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Snowman")
        {
            StopCoroutine(timer);
            GameObject.Destroy(gameObject);
            coll.gameObject.GetComponent<EnemyStats>().takeDamage(damage);
        }
    }
    private IEnumerator timeOut()
    {
        yield return new WaitForSeconds(timeToLive);
        StopCoroutine(timer);
        GameObject.Destroy(gameObject);
    }
}
