using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public Stats Player;
	public float Health;
	public GameObject[] Glocke;
	private float LastHealth;



	// Use this for initialization
	void Start () {
		Health = (Player.actualHealth / Player.maxHealth) * Glocke.Length;    //Health=12 //Glocke.Length ist 12
		LastHealth = Health;
	
	}
	
	// Update is called once per frame
	void Update () {
		Health = (Player.actualHealth / Player.maxHealth) * Glocke.Length;
		if (LastHealth != Health) {
			LastHealth = Health;

			for (var i = 0; i < Glocke.Length; i++) {
			
				Glocke [i].SetActive (i < Health);
			}
		}


	
	}
}
