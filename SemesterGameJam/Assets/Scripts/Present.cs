using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            FindObjectOfType<Inventory>().addResources(determineReward);
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
