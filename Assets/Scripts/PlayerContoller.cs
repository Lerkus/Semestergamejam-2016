using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

	public float playerSpeed = 10f;

	private bool right = false;
	private Vector2 lastDPRot = new Vector2 (0f, 0f);
	private Rigidbody2D rg;

	void Start() {
		rg = transform.parent.GetComponent<Rigidbody2D> ();
	}

	void Update() {
		float horizontalMove = Input.GetAxis ("Horizontal");
		float VerticalMove = Input.GetAxis ("Vertical");
		float dPad_X = Input.GetAxis ("DPad-XAxis");
		float dPad_Y = Input.GetAxis ("DPad-YAxis");

		// Player Movement
		Vector3 movement = new Vector3 (horizontalMove, VerticalMove, 0f);
		rg.AddForce (movement * playerSpeed);

		// Player's Hand Rotation
		// TODO change it for rotation for hand after adding sprites and change player's scaling according to player behavior
		if(dPad_X!=0 || dPad_Y!=0)	 {
			Vector2 direction = -((Vector2)((Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z - 90) * Vector2.right))).normalized;
			if ((direction.x < 0) && right) {
				right = false;
				Flip ();
			} else if (direction.x > 0 && !right) {
				right = true;
				Flip ();
			}
			Vector3 x = dPad_X * Vector3.right;
			Vector3 y = dPad_Y * Vector3.up;
			Vector3 dir = x + y;
			//dir.Normalize ();
			float RotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0f, 0f, RotZ -90);
		}
			
        if (Input.GetAxis("Attack") < 0)
            gameObject.GetComponent<Attack>().attack(-(Vector2)(Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z + 90) * Vector2.right));

        if (Input.GetButtonDown("Swap"))
            gameObject.GetComponent<Attack>().switchWeapon();      
    }

	void Flip() {
		Transform arm = transform;
		Transform body = transform.parent.GetChild(0);
		if (right) {
			arm.GetChild (1).gameObject.SetActive(false);
			arm.GetChild (0).gameObject.SetActive(true);
			body.GetChild (1).gameObject.SetActive(false);
			body.GetChild (0).gameObject.SetActive(true);
		} else {
			arm.GetChild (0).gameObject.SetActive(false);
			arm.GetChild (1).gameObject.SetActive(true);
			body.GetChild (0).gameObject.SetActive(false);
			body.GetChild (1).gameObject.SetActive(true);
		}
	}
}