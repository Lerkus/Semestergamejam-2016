using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //TODO: destroy the present and add items to inventory
        }
    }
}
