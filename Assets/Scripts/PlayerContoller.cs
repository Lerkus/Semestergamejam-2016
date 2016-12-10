using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

	public float playerSpeed = 10f;

	private bool fliped = false;
	private bool right = false;
	private Vector2 lastDPRot = new Vector2 (0f, 0f);

	void Update() {
		float horizontalMove = Input.GetAxis ("Horizontal");
		float VerticalMove = Input.GetAxis ("Vertical");
		float dPad_X = Input.GetAxis ("DPad-XAxis");
		float dPad_Y = Input.GetAxis ("DPad-YAxis");

		// Player Movement
		if (horizontalMove != 0) {
			transform.parent.transform.Translate (horizontalMove * playerSpeed * Vector3.right * Time.deltaTime, Space.World);
		}
		if (VerticalMove != 0) {
			transform.parent.transform.Translate (VerticalMove * playerSpeed * Vector3.up * Time.deltaTime, Space.World);
		}

//
//
//
		// Player's Hand Rotation
		// TODO change it for rotation for hand after adding sprites and change player's scaling according to player behavior
		if(dPad_X!=0 || dPad_Y!=0)	 {
//			if (transform.GetChild (0).eulerAngles.z > 30 && transform.GetChild (0).eulerAngles.z < 210) {
//				if (!fliped) {
//					Flip ();
//				}
//			} else {
//				if (fliped) {
//					Flip ();
//				}
//			}
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
//
//		// Hand rotation
//		if (dPad_X != 0 || dPad_Y != 0) {
//			Vector2 x = dPad_X * Vector2.right;
//			Vector2 y = dPad_Y * Vector2.up;
//			Vector2 dir = x + y;
//			//dir.Normalize ();
//			float RotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
//			if(RotZ != lastDPRot) {
//				Vector2 firstVector = 
//			}
//		}


        if (Input.GetAxis("Attack") < 0)
            gameObject.GetComponent<Attack>().attack(-(Vector2)(Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z) * Vector2.right));

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