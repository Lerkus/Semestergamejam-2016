using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public int damage = 1;
    public float timeToLive = 1.5f;
    private Coroutine timer;


    public void Awake()
    {
        timer = StartCoroutine(timeOut());
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Enemy")
        {
            coll.collider.GetComponent<EnemyStats>().takeDamage(damage);
            GameObject.Destroy(gameObject);
        }
    }
    private IEnumerator timeOut()
    {
        yield return new WaitForSeconds(timeToLive);
        StopCoroutine(timer);
        GameObject.Destroy(gameObject);
    }
}
