using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public GameObject[] Glocke;
	public int Health=12;
	private int LastHealth;



	// Use this for initialization
	void Start () {

		LastHealth = Health;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (LastHealth != Health) {
			LastHealth = Health;

			for (var i = 0; i < Glocke.Length; i++) {
			
				Glocke [i].SetActive (i < Health);
			}
		}


	
	}
}
