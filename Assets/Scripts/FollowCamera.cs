using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	private float interpVelocity;
	public GameObject target;
	public float lerpSpeed = 0.25f;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		if(target == null) {
			target = GameObject.FindGameObjectWithTag ("Player");
		}
		targetPos = transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (target) {
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity); 

			transform.position = Vector3.Lerp (transform.position, targetPos, lerpSpeed * Time.deltaTime);

		} else {
			target = GameObject.FindGameObjectWithTag ("Player");
		}
	}
}