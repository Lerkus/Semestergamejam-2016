using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            FindObjectOfType<Inventory>().addResources(determineReward());
            GameObject.Destroy(gameObject);
        }
    }

    int [] determineReward()
    {
        //TODO: Randomize Reward
        int[] reward = { 1, 5, 3 , 1, 5, 6, 0, 0, 0, 0, 0, 0};
        return reward;

    }
}
