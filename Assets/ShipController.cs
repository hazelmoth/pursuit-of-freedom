using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	Rigidbody rbody;
	Collider collider;
	float moveSpeed = 70f;
	float rotSpeed = 90f;
	float yawSpeed = 40f;
	bool isTurning;

	// Use this for initialization
	void Start () {
		rbody = this.GetComponent<Rigidbody> ();
		collider = GetComponentInChildren<Collider> ();
	}
		
	void OnCollisionEnter (Collision collision) {
		CourseManager.OnShipCrashed (this.gameObject);
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "Finish") {
			CourseManager.OnShipFinished ();
		}
	}

	// Update is called once per frame
	void Update () {
		MoveForward (moveSpeed * Time.deltaTime);
		float roll =  (Input.GetAxis ("Horizontal") * rotSpeed * -1 * Time.deltaTime);
		float pitch = (Input.GetAxis ("Vertical") * rotSpeed * Time.deltaTime);
		float yaw = (Input.GetAxis ("Yaw") * yawSpeed * Time.deltaTime);
		Turn (roll, pitch, yaw);
	}

	void MoveForward (float distance) {
		rbody.MovePosition (transform.position + transform.forward * distance);
	}

	void TurnRoll (float amount) {
		rbody.MoveRotation (Quaternion.Euler (transform.rotation.eulerAngles + transform.forward * amount));
	}

	void TurnPitch (float amount) {
		rbody.MoveRotation (Quaternion.Euler (transform.rotation.eulerAngles + transform.right * amount));
	}

	void Turn (float amountRoll, float amountPitch, float amountYaw) {
		Vector3 newRot = transform.rotation.eulerAngles;
		newRot += transform.forward * amountRoll;
		newRot += transform.right * amountPitch;
		transform.RotateAround (transform.position, transform.forward, amountRoll);
		transform.RotateAround (transform.position, transform.right, amountPitch);
		transform.RotateAround (transform.position, transform.up, amountYaw);
		//rbody.MoveRotation (Quaternion.Euler (newRot));
	}
}
