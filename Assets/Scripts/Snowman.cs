using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class Snowman : MonoBehaviour {
	public Transform target;

    public int damage = 5;

	// How many times each second we will update our path
	public float updateRate = 2f;

	// Catching
	private Seeker seeker;
	private Rigidbody2D rb;

	// The calculated path
	public Path path;

	// The AI's speed per second
	public float speed = 300f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool pathIsEnded = false;

	// the next distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;

	// The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	void Start() {
		seeker = transform.GetComponent<Seeker> ();
		rb = transform.GetComponent<Rigidbody2D> ();

		if(target == null) {
			Debug.LogError ("No Target is set.");
			return;
		}

		// Start a new Path, return the result to OnPathComplete
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		StartCoroutine (UpdatePath());
	}

	IEnumerator UpdatePath() {
		if (target == null) {
			// TODO: Insert a player search here.
			return false;
		}

		seeker.StartPath (transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds (1f/updateRate);
		StartCoroutine (UpdatePath());
	}

	public void OnPathComplete (Path p) {
		if(!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	void FixedUpdate() {
		if (target == null) {
			// TODO: Insert a player search here.
			return;
		}

		// TODO: Always look at player (snowman eyes)

		if (path == null)
			return;

		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;

		// Direction of the next waypoint
		Vector3 dir = path.vectorPath[currentWaypoint] - transform.position;
		dir *= speed * Time.fixedDeltaTime;

		// Move the AI
		rb.AddForce(dir, fMode);

		float dist = Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]);
		if (dist < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponentInParent<PlayerStats>().takeDamage(damage);
        }
    }
}
