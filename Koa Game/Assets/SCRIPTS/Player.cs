using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
float movementSpeed;
	public float speed = 10;
	public float runspeed = 40;
	public float turningSpeed = 60;
	void Update() {
		if (Input.GetKey (KeyCode.LeftShift)) {
			movementSpeed = runspeed;
		} else {
			movementSpeed = speed;
	}
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);
	}
}