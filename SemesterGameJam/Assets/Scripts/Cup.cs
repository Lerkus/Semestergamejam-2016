using UnityEngine;
using System.Collections;

public class Cup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Snowman")
        {
            //TODO: damage Snowman
        }
    }
}
