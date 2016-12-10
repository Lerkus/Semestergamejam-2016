using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

	public float playerSpeed = 10f;

	void FixedUpdate() {
		float horizontalMove = Input.GetAxis ("Horizontal");
		float VerticalMove = Input.GetAxis ("Vertical");
		float dPad_X = Input.GetAxis ("DPad-XAxis");
		float dPad_Y = Input.GetAxis ("DPad-YAxis");

		// Player Movement
		if (horizontalMove != 0) {
			transform.Translate (horizontalMove * playerSpeed * Vector3.right * Time.deltaTime, Space.World);
		}
		if (VerticalMove != 0) {
			transform.Translate (VerticalMove * playerSpeed * Vector3.up * Time.deltaTime, Space.World);
		}

		// Player's Hand Rotation
		// TODO change it for rotation for hand after adding sprites and change player's scaling according to player behavior
		if(dPad_X!=0 || dPad_Y!=0)	 {
			Vector3 x = dPad_X * Vector3.right;
			Vector3 y = dPad_Y * Vector3.up;
			Vector3 dir = x + y;
			dir.Normalize ();
			float RotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0f, 0f, RotZ);
		}

        if (Input.GetAxis("Attack") < 0)
            gameObject.GetComponent<Attack>().attack(-(Vector2)(Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z) * Vector2.right));

        if (Input.GetButtonDown("Jump"))
            gameObject.GetComponent<Attack>().switchWeapon();
    }
}