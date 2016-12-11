using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {
    public int maxDropAmount = 2;
    public Sprite[] presentSprites;


    public void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = presentSprites[Mathf.RoundToInt((float)(presentSprites.Length) * Random.value)];
    }

	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameMaster.getGameMaster().GetComponent<Inventory>().addResources(determineReward());
            GameObject.Destroy(gameObject);
        }
    }

    int [] determineReward()
    {
        int[] reward = new int[12];
        for(int i = 0; i < reward.Length/2; i++)
        {
            reward[i] = Mathf.RoundToInt(Random.value * maxDropAmount);
        }
        for (int i = reward.Length / 2 + 1; i < reward.Length; i++)
        {
            reward[i] = Mathf.RoundToInt(Random.value);
        }

        return reward;
    }
}
